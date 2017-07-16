using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Linq;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Modules;
using bS.Sked.Extensions.Common.Helpers.FlatFiles;
using bS.Sked.Extensions.Common.Model;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Extensions.Common.ViewModel;
using bS.Sked.Model.Elements.Properties;
using System.Collections;
using bS.Sked.Model.Interfaces.DTO;
using System.Collections.Generic;
using bS.Sked.Model.DTO;

namespace bS.Sked.Extensions.Common
{
    public class CommonModule : ModuleBase
    {
        private IRepository<IPersisterEntity> _repository;

        public CommonModule(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
            implementedElementTypes = new string[]
            {
                StaticContent.fromFlatFlieToTable,
                StaticContent.fromDbQueryToTable,
                StaticContent.fromTableToFile
            };

            supportedElementTypes = new string[]
           {
                StaticContent.fromFlatFlieToTable,
                StaticContent.fromDbQueryToTable,
                StaticContent.fromTableToFile
           };
        }

        [Obsolete]
        public override IExecutableElementBaseViewModel AddNewElement(IExecutableElementBaseViewModel element)
        {
            switch (element.ElementTypePersistingId)
            {
                case StaticContent.fromFlatFlieToTable:
                    return addNewElementGeneric<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>(element);
                default:
                    return null;
            }
        }


        public override IExecutableElementBaseViewModel AddElement(string elementPID, IDictionary<string, IField> properties)
        {
            switch (elementPID)
            {
                case StaticContent.fromFlatFlieToTable:
             
                    var vm = AutoMapper.Mapper.Map<FromFlatFlieToTableElementViewModel>(properties);

                    return addNewElementGeneric<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>(vm);
                default:
                    return null;
            }
        }

        private IExecutableElementBaseViewModel addNewElementGeneric<ViewModel, Model>(IExecutableElementBaseViewModel element)
            where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = AutoMapper.Mapper.Map<Model>(element);

            //   var t = _repository.BeginTransaction();
            _repository.Add(model);
            //   t.Commit();
            element = AutoMapper.Mapper.Map<ViewModel>(model);
            return element;
        }

        public override IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement)
        {
            switch (executableElement.ElementType.PersistingId)
            {
                case StaticContent.fromFlatFlieToTable:
                    return executeFromFlatFlieToTable(context, executableElement);
                default:
                    return new ExtensionExecuteResult
                    {
                        IsSuccessfullyCompleted = false,
                        Message = $"The element with PID '{executableElement.ElementType.PersistingId}' is not implemented yet.",
                        Errors = new string[] { "Can not init Main Object" }
                    };
            }
        }

        private IExtensionExecuteResult executeFromFlatFlieToTable(IExtensionContext context, IExecutableElementModel executableElement)
        {
            var element = executableElement as FromFlatFlieToTableElementModel;
            var mainObject = context as CommonMainObjectModel;

            if (!mainObject.InitializeContext()) return new ExtensionExecuteResult
            {
                IsSuccessfullyCompleted = false,
                Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                Errors = new string[] { "Can not init Main Object" }
            };

            try
            {
                var parser = new GenericParserAdapter(element.InFileObject.FileFullPath);
                parser.SkipStartingDataRows = element.SkipStartingRows;
                parser.ColumnDelimiter = element.SeparatorValue ?? ';';
                parser.MaxRows = element.LimitToRows;
                element.OutTableObject = new TableObjectModel();
                element.OutTableObject.Table = parser.GetDataTable();
            }
            catch (Exception ex)
            {
                return new ExtensionExecuteResult
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                    Errors = new string[] { ex.GetBaseException().Message }
                };
            }

            return new ExtensionExecuteResult
            {
                IsSuccessfullyCompleted = true,
                Message = $"Flat File '{element.InFileObject.FileFullPath}' has imported {element.OutTableObject.Table?.Rows.Count ?? 0} rows successfully."
            };
        }

        //public override bool IsSupported(IExecutableElementModel executableElement)
        //{
        //    return supportedElementTypes?.Contains(executableElement.ElementType.PersistingId) ?? false;
        //}
        //public override bool IsImplemented(IExecutableElementModel executableElement)
        //{
        //    return implementedElementTypes?.Contains(executableElement.ElementType.PersistingId) ?? false;
        //}

    }
}
