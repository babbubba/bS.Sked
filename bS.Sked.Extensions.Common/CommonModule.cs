﻿using bS.Sked.Model.Interfaces.Modules;
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
using System.IO;
using bS.Sked.Model.Elements;

namespace bS.Sked.Extensions.Common
{
    /// <summary>
    /// The 'Common' extension's module. It implements some common elements execution.
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Modules.ModuleBase" />
    public class CommonModule : ModuleBase
    {
        private IRepository<IPersisterEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonModule"/> class and define the supported and implemented element types by their PID (persisting identifier).
        /// </summary>
        /// <param name="repository">The repository.</param>
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


        private IExecutableElementBaseViewModel addNewElementGeneric<ViewModel, Model>(IExecutableElementBaseViewModel element)
            where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = AutoMapper.Mapper.Map<Model>(element);
            _repository.Add(model);
            element = AutoMapper.Mapper.Map<ViewModel>(model);
            return element;
        }
        private IExecutableElementBaseViewModel editElementGeneric<ViewModel, Model>(ViewModel vm)
               where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = _repository.GetQuery<IExecutableElementModel>().Single(x=> x.Id == Guid.Parse( vm.Id));
            AutoMapper.Mapper.Map(vm, model);
            _repository.Update(model);
            vm = AutoMapper.Mapper.Map<ViewModel>(model);
            return vm;
        }
        private void deleteElementGeneric<ViewModel, Model>(ViewModel vm)
               where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = _repository.GetQuery<IExecutableElementModel>().Single(x=> x.Id == Guid.Parse( vm.Id));
            _repository.Delete(model);
        }


        /// <summary>
        /// Executes From Flat Flie to Table element.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns></returns>
        private IExtensionExecuteResult executeFromFlatFlieToTable(IExtensionContext context, IExecutableElementModel executableElement)
        {

            log.Info($"Start execution of {StaticContent.fromFlatFlieToTable} element with id: {executableElement.Id}");

            var element = executableElement as FromFlatFlieToTableElementModel;
            var mainObject = context as CommonMainObjectModel;

            if (!mainObject.InitializeContext()) return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                Errors = new string[] { "Can not init Main Object" },
                SourceId = executableElement.Id.ToString(),
                MessageType = MessageTypeEnum.Error
            };

            // Add this element to the context for future need.
            context.Elements.Add(element);
            if (element.Instances == null) element.Instances = new List<IElementInstanceModel>();
            var elementInstance = new ElementInstanceModel();
            elementInstance.StartTime = DateTime.UtcNow;
            elementInstance.Progress = 1;
            //TODO: Finisci di creare l'istanza dell'elelemnto poi mettila nel progetto CORE che devi creare per le funzioni base che ereditano tutti i moduli o extensions
            // Li dentro mettici anche le extensions ed i metodi statici comuni!!!

            // Check if input file exist
            if (!File.Exists(element.InFileObject.FileFullPath))
            {
                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' not exists or access is denied.",
                    SourceId = executableElement.Id.ToString(),
                    MessageType = MessageTypeEnum.Error
                };
            }

            try
            {
                log.Debug("Start parsing input flat file.");
                //Start parsing file
                var parser = new GenericParserAdapter(element.InFileObject.FileFullPath);

                parser.SkipStartingDataRows = element.SkipStartingDataRows;
                parser.FirstRowHasHeader = element.FirstRowHasHeader;
                parser.ColumnDelimiter = element.SeparatorValue ?? ';';
                parser.MaxRows = element.LimitToRows;
                element.OutTableObject = new TableObjectModel();
                element.OutTableObject.Table = parser.GetDataTable();
            }
            catch (Exception ex)
            {
                log.Error("Erorr parsing input flat file.", ex);
                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                    Errors = new string[] { $"Error reading Flat File. {ex.GetBaseException().Message}" },
                    SourceId = executableElement.Id.ToString(),
                    MessageType = MessageTypeEnum.Error
                };
            }

            return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = true,
                Message = $"Flat File '{element.InFileObject.FileFullPath}' has imported {element.OutTableObject.Table?.Rows.Count ?? 0} rows successfully.",
                SourceId = executableElement.Id.ToString(),
                MessageType = MessageTypeEnum.Info
            };
        }


        /// <summary>
        /// Executes the specified executable element in the specified extension's context.
        /// </summary>
        /// <param name="context">The extension's context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns>
        /// The result of the execution.
        /// </returns>
        public override IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement)
        {
            switch (executableElement.ElementType.PersistingId)
            {
                case StaticContent.fromFlatFlieToTable:
                    return executeFromFlatFlieToTable(context, executableElement);
                default:
                    return new ExtensionExecuteResultModel
                    {
                        IsSuccessfullyCompleted = false,
                        Message = $"The element with PID '{executableElement.ElementType.PersistingId}' is not implemented yet in this module.",
                        Errors = new string[] { "Can not init Main Object" },
                        SourceId = executableElement.Id.ToString()
                    };
            }
        }

        public override IExecutableElementBaseViewModel ElementGet(string elementId, string elementPID)
        {
            switch (elementPID)
            {
                case StaticContent.fromFlatFlieToTable:
                    return AutoMapper.Mapper.Map<FromFlatFlieToTableElementViewModel>(_repository.GetQuery<FromFlatFlieToTableElementModel>().Single(x=>x.Id == Guid.Parse(elementId)));
                default:
                    return null;
            }
        }


        /// <summary>
        /// Adds the specified executable element to the database.
        /// </summary>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public override IExecutableElementBaseViewModel ElementAdd(string elementPID, IDictionary<string, IField> properties)
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
        /// <summary>
        /// Edits the specified executable element in the database.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public override IExecutableElementBaseViewModel ElementEdit(string elementId, string elementPID, IDictionary<string, IField> properties)
        {
            switch (elementPID)
            {
                case StaticContent.fromFlatFlieToTable:

                    var vm = AutoMapper.Mapper.Map<FromFlatFlieToTableElementViewModel>(properties);
                    vm.Id = elementId;
                    vm.ElementTypePersistingId = elementPID;

                    return editElementGeneric<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>(vm);
                default:
                    return null;
            }
        }
        /// <summary>
        /// Deletes the specified executable element from the database..
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <exception cref="ApplicationException">This Element Persisting Id is not implemented by this module.</exception>
        public override void ElementDelete(string elementId, string elementPID)
        {
            switch (elementPID)
            {
                case StaticContent.fromFlatFlieToTable:
                    var model = _repository.GetQuery<FromFlatFlieToTableElementModel>().Single(x=>x.Id == Guid.Parse(elementId));
                    _repository.Delete(model);
                    break;
                default:
                    throw new ApplicationException("This Element Persisting Id is not implemented by this module.");
            }
        }

       
    }
}
