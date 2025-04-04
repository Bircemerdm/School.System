 $(function() { 
    var l =abp.localization.getResource("System");
    var schoolService=window.school.system.roles.guardian;
    
    var dataTableColumns=[
        {
            rowAction:
                {
                    items:[{
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
{ data: "guardianIdentificationNumber" },
{ data: "guardianName" },
{ data: "guardianSurname" },
{ data: "guardianPhone" },

        
];
var dataTable = $("#GuardiansTable").DataTable(abp.libs.datatables.normalizeConfiguration({
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

$("#NewStudentButton").click(function (e) {
    e.preventDefault();
    createModal.open();
});
 });


