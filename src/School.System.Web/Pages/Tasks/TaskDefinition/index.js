$(function () {
    var l =abp.localization.getResource("System");
    var schoolService=window.school.system.tasks.taskDefinition;
    
    var createModal=new abp.ModalManager({
        viewUrl:abp.path+"Tasks/TaskDefinition/CreateModal",
        scriptUrl: abp.appPath +"Pages/Tasks/TaskDefinition/createModal.js",
        modalClass:"taskDefinitionCreate",
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Tasks/TaskDefinition/EditModal",
        scriptUrl: abp.appPath + "Pages/Tasks/TaskDefinition/editModal.js",
        modalClass: "taskDefinitionEdit"
    });
    var dataTableColumns=[
        {
            rowAction: {
                items: [{
                    text: l("Edit"),

                    action: function (data) {
                        editModal.open({
                            id: data.record.id
                        });
                    }
                },
                    {
                        text: l("Delete"),
                        confirmMessage: function () {
                            return l("DeleteConfirmationMessage");
                        },
                        action: function (data) {
                            schoolService.delete(data.record.id)
                                .then(function () {
                                    abp.notify.success(l("SuccessfullyDeleted"));
                                    dataTable.ajax.reloadEx();
                                });
                        }
                    }
                ]
            },
            width: "1rem"
        },
        {data:"title"},
        {data:"description"},
        {data:"dueDate"},
     
    
    ];
    var dataTable=$("#TaskDefinitionsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(schoolService.getList),
        columnDefs: dataTableColumns,
        lengthMenu: [10, 25, 50, 100, 250, 500, 1000],
        pageLength: 50
    }));
    createModal.onResult(function(){
        dataTable.ajax.reloadEx();
    });
    editModal.onResult(function(){
        dataTable.ajax.reloadEx();
    });
    $("#NewTaskButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});