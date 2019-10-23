var controlConfig = {
    pageSize: 10,
    pageIndex: 1
};

var departmentController = {
    init: function () {
        departmentController.loadDepartments();
        departmentController.registerEvent();
    },

    registerEvent: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            $('#modalAddOrUpdate').modal('show');
            departmentController.clearForm();
        });

        $('.btnUpdate').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $("#modalAddOrUpdate").modal('show');
            departmentController.loadDetail(id);
        });

        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            bootbox.confirm("Are you sure to delete these departments?", function (result) {
                if (result) {
                    var listId = "";
                    $.each($('.chkDelete'), function (i, item) {
                        if ($(this).prop('checked')) {
                            listId = listId + $(this).data("id") + "-";
                        }
                    });
                    $.ajax({
                        url: "/Admin/Department/DeleteAll",
                        data: { listId: JSON.stringify(listId) },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status === true) {
                                toastr.success(response.message);                                                                
                                departmentController.loadDepartments();
                                departmentController.registerEvent();
                            }
                            else {
                                console(response.message);
                            }
                        }
                    });
                }
            });
        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            bootbox.confirm("Are you sure to delete this?", function (result) {
                if (result) {
                    departmentController.deleteDepartment(id);
                }
            });
        });

        $('.btnStatus').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data("id");
            $.ajax({
                url: '/Admin/Department/ChangeStatus',
                type: 'POST',
                dataType: 'json',
                data: { id: id },
                success: function (response) {
                    if (response.status) {
                        btn.text('Activated');
                        btn.removeClass('badge-danger');
                        btn.addClass('badge-success');
                        toastr.success("Activate " + response.data);
                    }
                    else {
                        btn.text('Disabled');
                        btn.addClass('badge-danger');
                        btn.removeClass('badge-success');
                        toastr.warning("Disable " + response.data);
                    }
                }
            });
        });

        $('#btnSave').off('click').on('click', function () {
            departmentController.saveData();
        });
    },

    loadDetail: function (id) {
        $.ajax({
            url: '/Admin/Department/GetDepartmentDetail',
            data: { id: id },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status === true) {
                    $('#txtID').val(response.data.ID);
                    $('#txtDepartment').val(response.data.Name);                    
                    $('#chkStatus').prop('checked', response.data.Status);
                }               
            },
            error: function (err) {
                console.log(err);
            }
        });
    },

    saveData: function () {     
        var department = $('#txtDepartment').val();
        if (department === null || department === "") {
            $('#txtDepartment').addClass("invalidate-input");
            $('#warningDepartment').show();
            $('#txtDepartment').focus();
        }
        else {
            var id = $('#txtID').val();
            var status = $('#chkStatus').prop('checked');
            var data = {
                id: id,
                name: department,
                status: status
            };
            $.ajax({
                url: '/Admin/Department/AddOrUpdate',
                data: { model: JSON.stringify(data) },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status === true) {                       
                        toastr.success(response.message);
                        departmentController.clearForm();
                        $('#modalAddOrUpdate').modal('hide');
                        departmentController.loadDepartments();
                        departmentController.registerEvent();
                    }
                    else {
                        toastr.error(response.message);
                        departmentController.clearForm();
                        $('#modalAddOrUpdate').modal('hide');                     
                        departmentController.registerEvent();
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    },

    clearForm: function () {
        $('#txtID').val(0);
        $('#txtDepartment').val("");
        $('#chkStatus').prop("checked", false);
    },

    deleteDepartment: function (id) {
        $.ajax({
            url: '/Admin/Department/Delete',
            type: 'POST',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    toastr.success("Delete department successfully");
                    departmentController.loadDepartments();
                    departmentController.registerEvent();
                }
                else {
                    toastr.error("Delete department failed");
                    departmentController.registerEvent();
                }
            }
        });
    },

    loadDepartments: function () {
        $.ajax({
            url: '/Admin/Department/LoadDepartments',
            type: 'GET',
            data: {
                page: controlConfig.pageIndex,
                pageSize: controlConfig.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    if (response.totalRow != 0) {
                        var data = response.data;
                        var html = '';
                        var template = $('#template').html();
                        $.each(data, function (i, item) {
                            html += Mustache.render(template, {
                                Index: (i + 1),
                                ID: item.ID,
                                Department: item.Name,
                                Status: item.Status === true ? '<a href="#" class="badge badge-success btnStatus" data-id="' + item.ID + '">Activated</a>' : '<a href="#" class="badge badge-danger btnStatus" data-id="' + item.ID + '">Locked</a>'
                            });
                        });
                        $("#tblDepartments").html(html);
                        departmentController.paging(response.totalRow, function () {
                            departmentController.loadDepartments();
                        });
                        departmentController.registerEvent();
                    }
                    else {
                        $("#tblDepartments").html("<td colspan='5'>No data to display</td>");
                    }
                }
            }
        });
    },

    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / controlConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                controlConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
};

departmentController.init();