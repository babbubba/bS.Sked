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
using System.IO;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.MainObjects;
using bS.Sked.Shared.Helpers;

namespace bS.Sked.Extensions.Common
{
    /// <summary>
    /// The 'Common' extension's module. It implements some common elements execution.
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Modules.ModuleBase" />
    public class CommonModule : ModuleBase
    {
        private readonly IRepository<IPersisterEntity> _repository;
        private readonly PersisterHelper _persisterHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonModule"/> class and define the supported and implemented element types by their PID (persisting identifier).
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommonModule(IRepository<IPersisterEntity> repository, PersisterHelper persisterHelper)
        {
            _repository = repository;
            _persisterHelper = persisterHelper;
            implementedElementTypes = new string[]
            {
                StaticContent.fromFlatFlieToTable,
                StaticContent.fromDbQueryToTable,
                StaticContent.fromTableToFile,
                StaticContent.commonMainObject
            };

            supportedElementTypes = new string[]
           {
                StaticContent.fromFlatFlieToTable,
                StaticContent.fromDbQueryToTable,
                StaticContent.fromTableToFile,
                StaticContent.commonMainObject
           };
        }


        //private IExecutableElementBaseViewModel addNewElementGeneric<ViewModel, Model>(IExecutableElementBaseViewModel element)
        //    where Model : class, IPersisterEntity
        //    where ViewModel : IExecutableElementBaseViewModel
        //{
        //    var model = AutoMapper.Mapper.Map<Model>(element);
        //    _repository.Add(model);
        //    element = AutoMapper.Mapper.Map<ViewModel>(model);
        //    return element;
        //}
        //private IExecutableElementBaseViewModel editElementGeneric<ViewModel, Model>(ViewModel vm)
        //       where Model : class, IPersisterEntity
        //    where ViewModel : IExecutableElementBaseViewModel
        //{
        //    var model = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(vm.Id));
        //    AutoMapper.Mapper.Map(vm, model);
        //    _repository.Update(model);
        //    vm = AutoMapper.Mapper.Map<ViewModel>(model);
        //    return vm;
        //}
        //private void deleteElementGeneric<ViewModel, Model>(ViewModel vm)
        //       where Model : class, IPersisterEntity
        //    where ViewModel : IExecutableElementBaseViewModel
        //{
        //    var model = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(vm.Id));
        //    _repository.Delete(model);
        //}
        //private IExecutableMainObjectBaseViewModel addNewMainObjectGeneric<ViewModel, Model>(IExecutableMainObjectBaseViewModel mainObject)
        //    where Model : class, IPersisterEntity
        //    where ViewModel : IExecutableMainObjectBaseViewModel
        //{
        //    var model = AutoMapper.Mapper.Map<Model>(mainObject);
        //    _repository.Add(model);
        //    mainObject = AutoMapper.Mapper.Map<ViewModel>(model);
        //    return mainObject;
        //}


        /// <summary>
        /// Executes From Flat Flie to Table element.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns></returns>
        private IExtensionExecuteResult executeFromFlatFlieToTable(IMainObjectModel context, IExecutableElementModel executableElement, IElementInstanceModel elementInstance)
        {
            log.Info($"Start execution of {StaticContent.fromFlatFlieToTable} element with id: {executableElement.Id}");

            var element = executableElement as FromFlatFlieToTableElementModel;
            var mainObject = context as CommonMainObjectModel;

            if (!mainObject.InitializeContext())
            {
                elementInstance.HasErrors++;
                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                    Errors = new string[] { "Can not init Main Object" },
                    SourceId = executableElement.Id.ToString(),
                    MessageType = MessageTypeEnum.Error
                };
            }

            // Add this element to the context for future need.
            context.Elements.Add(element);

            // Check if input file exist
            if (!File.Exists(element.InFileObject.FileFullPath))
            {
                elementInstance.HasErrors++;
                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' not exists or access is denied.",
                    Errors = new string[] { $"Flat File '{element.InFileObject.FileFullPath}' not exists or access is denied." },
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
                elementInstance.HasErrors++;
                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Flat File '{element.InFileObject.FileFullPath}' has not imported.",
                    Errors = new string[] { $"Error reading Flat File. {ex.GetBaseException().Message}" },
                    SourceId = executableElement.Id.ToString(),
                    MessageType = MessageTypeEnum.Error
                };
            }

            elementInstance.IsSuccessfullyCompleted = true;
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
        /// <param name="mainObject">The extension's context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns>
        /// The result of the execution.
        /// </returns>
        public override IExtensionExecuteResult Execute(IMainObjectModel mainObject, IExecutableElementModel executableElement, IElementInstanceModel elementInstance)
        {
            switch (executableElement.ElementType.PersistingId)
            {
                case StaticContent.fromFlatFlieToTable:
                    return executeFromFlatFlieToTable(mainObject, executableElement, elementInstance);
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
                    return AutoMapper.Mapper.Map<FromFlatFlieToTableElementViewModel>(_repository.GetQuery<FromFlatFlieToTableElementModel>().Single(x => x.Id == Guid.Parse(elementId)));
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

                    return _persisterHelper.addNewElementGeneric<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>(vm);
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

                    return _persisterHelper.editElementGeneric<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>(vm);
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
                    var model = _repository.GetQuery<FromFlatFlieToTableElementModel>().Single(x => x.Id == Guid.Parse(elementId));
                    _repository.Delete(model);
                    break;
                default:
                    throw new ApplicationException("This Element Persisting Id is not implemented by this module.");
            }
        }

        public override IExecutableMainObjectBaseViewModel MainObjectAdd(string mainObjectPID, IDictionary<string, IField> properties)
        {
            switch (mainObjectPID)
            {
                case StaticContent.commonMainObject:

                    var vm = AutoMapper.Mapper.Map<CommonMainObjectViewModel>(properties);

                    return _persisterHelper.addNewMainObjectGeneric<CommonMainObjectViewModel, CommonMainObjectModel>(vm);
                default:
                    return null;
            }
        }


    }
}
