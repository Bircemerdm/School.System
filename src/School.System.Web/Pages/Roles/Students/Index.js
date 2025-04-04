$(function(){
    var l =abp.localization.getResource("System");
    var schoolService=window.school.system.roles.student;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Roles/Students/CreateModal",
        scriptUrl: abp.appPath + "Pages/Roles/Students/createModal.js",
        modalClass: "studentCreate"
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Roles/Students/EditModal",
        scriptUrl: abp.appPath + "Pages/Roles/Students/editModal.js",
        modalClass: "studentEdit"
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
        { data: "studentName" },
        { data: "studentSurname" },
        { data: "studentBirthday" },
        { data: "studentPhone" },
        { data: "class" },
        { data: "brach" },
        { data: "schoolFee" },
        { data: "guardianId" },
        { data: "studentIdentificationNumber" },
        
        
    ];
    var dataTable = $("#StudentsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
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
    $("#NewStudentButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});