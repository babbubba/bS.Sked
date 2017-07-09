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

        public override IExecutableElementBaseViewModel AddNewElement(IExecutableElementBaseViewModel element)
        {
            switch (element.ElementTypePersistingId)
            {
                case StaticContent.fromFlatFlieToTable:
                    throw new NotImplementedException();
                    break;
                default:
                    return null;
            }
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
                Errors= new string[] {"Can not init Main Object"}
            };

            try
            {
                var parser = new GenericParserAdapter(element.InFileObject.FileFullPath);
                parser.SkipStartingDataRows = element.SkipStartingRows;
                parser.ColumnDelimiter = element.SeparatorValue ?? ';';
                parser.MaxRows = element.LimitToRows;
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
