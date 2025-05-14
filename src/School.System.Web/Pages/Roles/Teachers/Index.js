$(function(){
    var l =abp.localization.getResource("System");
    var schoolService=window.school.system.roles.teacher;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Roles/Teachers/CreateModal",
        scriptUrl: abp.appPath + "Pages/Roles/Teachers/createModal.js",
        modalClass: "teacherCreate"
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Roles/Teachers/EditModal",
        scriptUrl: abp.appPath + "Pages/Roles/Teachers/editModal.js",
        modalClass: "teacherEdit"
    });

    var dataTableColumns=[
        {
            rowAction:{
                items:[{
                    text: l("Edit"),

                    action: function (data) {
                        editModal.open({
                            id: data.record.id
                        });
                    }
                },
                    {
                        text:l("Delete"),
                        confirmMessage: function () {
                            return l("DeleteConfirmationMessage");
                        },
                        action: function (data) {
                            schoolService.delete(data.record.id)
                                .then(function(){
                                    abp.notify.success(l("SuccessfullyDeleted"));
                                    dataTable.ajax.reloadEx();
                                });
                        }
                    }
                ]
            },
            width: "1rem"
        },
        { data: "teacherIdentificationNumber" },
        { data: "teacherName" },
        { data: "teacherSurname" },
        { data: "type" },
        { data: "teacherBirthday" },
        { data: "teacherPhone" },
        { data: function(row){ return row.salary+' '+"₺"} },
    


    ];
    var dataTable = $("#TeachersTable").DataTable(abp.libs.datatables.normalizeConfiguration({
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
    $("#NewTeacherButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});