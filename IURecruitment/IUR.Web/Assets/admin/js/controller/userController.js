var userController = {
    init: function () {
        userController.loadUsers();
        userController.registerEvent();
    },

    registerEvent: function () {       
        $('.txtFullname').off('keypress').on('keypress', function (e) {
            if (e.which == 13) // Enter
            {
                var id = $(this).data('id');
                var value = $(this).val();
                userController.updateFullname(id, value);
            }
        });

        $('.txtPhone').off('keypress').on('keypress', function (e) {
            if (e.which == 13) // Enter
            {
                var id = $(this).data('id');
                var value = $(this).val();
                userController.updatePhone(id, value);
            }
        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            bootbox.confirm("Are you sure to delete this?", function (result) {
                if (result) {
                    userController.deleteUser(id);
                }
            });
        });

        $('.btnStatus').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data("id");
            $.ajax({
                url: '/Admin/User/ChangeStatus',
                type: 'POST',
                dataType: 'json',
                data: { id: id },
                success: function (response) {
                    if (response.status) {
                        btn.text('Activated');
                        btn.removeClass('badge-danger');
                        btn.addClass('badge-success');
                        toastr.success('Activated ' + response.data);
                    }
                    else {
                        btn.text('Disabled');
                        btn.addClass('badge-danger');
                        btn.removeClass('badge-success');
                        toastr.error('Disabled ' + response.data);
                    }
                }
            });
        });

        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            bootbox.confirm("Are you sure to delete these users?", function (result) {
                if (result) {
                    var listId = "";
                    $.each($('.chkDelete'), function (i, item) {
                        if ($(this).prop('checked')) {
                            listId = listId + $(this).data("id") + "-";
                        }
                    });
                    $.ajax({
                        url: "/Admin/User/DeleteAll",
                        data: { listId: JSON.stringify(listId) },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status === true) {
                                toastr.success(response.message);
                                userController.loadUsers();
                                userController.registerEvent();
                            }
                            else {
                                console(response.message);
                            }
                        }
                    });
                }
            });
        });

        $('#txtPassword').off('keyup').on('keyup', function () {
            userController.comparePasswords();
        });
        $('#txtPassword2').off('keyup').on('keyup', function () {
            userController.comparePasswords();
        });

        $('#btnSave').off('click').on('click', function () {
            userController.submitForm();
        });

    },

    submitForm: function () {
        var username = $('#txtUsername').val();
        var password = $('#txtPassword').val();
        var fullname = $('#txtFullname').val();
        var phone = $('#txtPhone').val();
        var status = $('#chkStatus').prop('checked');
        if (username == "" || password == "" || fullname == "") {
            toastr.warning("Make sure to enter username, password and fullname");
        }
        else {
            var data = {
                Username: username,
                HashedPassword: password,
                Phone: phone,
                Fullname: fullname,
                Status: status
            };
            $.ajax({
                url: '/Admin/User/Create',
                type: 'POST',
                dataType: 'json',
                data: { model: JSON.stringify(data) },
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);
                        $('#modalAdd').modal('hide');
                        userController.clearForm();
                        userController.loadUsers();
                        userController.registerEvent();
                    }
                    else {
                        toastr.error(response.message);
                    }
                }
            });
        }
    },  

    clearForm: function () {
        $('#txtUsername').val("");
        $('#txtPassword').val("");
        $('#txtPassword2').val("");
        $('#txtFullname').val("");
        $('#txtPhone').val("");
        $('#chkStatus').prop('checked', true);
        $('#warning-password').hide();
        $('#matching-password').hide();
        $('#btnSave').prop('disabled', true);
    },

    comparePasswords: function () {
        var pass = $('#txtPassword').val();
        var conpass = $('#txtPassword2').val();
        if (pass != conpass) {
            $('#txtPassword').addClass('invalidate-input');
            $('#txtPassword2').addClass('invalidate-input');
            $('#warning-password').show();
            $('#matching-password').hide();
            $('#btnSave').prop('disabled', true);         
        }
        else {
            $('#txtPassword').removeClass('invalidate-input');
            $('#txtPassword2').removeClass('invalidate-input');
            $('#warning-password').hide();
            $('#matching-password').show();
            $('#btnSave').prop('disabled', false);     
        }
    },

    deleteUser: function (id) {
        $.ajax({
            url: '/Admin/User/Delete',
            type: 'POST',
            dataType: 'json',
            data: {
                id: id
            },
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    userController.loadUsers();
                    userController.registerEvent();
                }
                else {
                    toastr.error(response.message);
                    userController.registerEvent();
                }
            }
        });
    },

    updateFullname: function (id, value) {
        var data = {
            ID: id,
            Fullname: value
        };
        $.ajax({
            url: '/Admin/User/UpdateFullname',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    userController.registerEvent();
                }
                else {
                    toastr.error("Updated user's fullname failed");
                    userController.registerEvent();
                }
            }
        });
    },

    updatePhone: function (id, value) {
        var data = {
            ID: id,
            Phone: value
        };
        $.ajax({
            url: '/Admin/User/UpdatePhone',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    userController.registerEvent();
                }
                else {
                    toastr.error("Update user's phone failed");
                    userController.registerEvent();
                }
            }
        });
    },

    loadUsers: function () {
        $.ajax({
            url: '/Admin/User/LoadUsers',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Username: item.Username,
                            Fullname: item.Fullname,
                            CreatedDate: item.CreatedDateToString,
                            Phone: item.Phone,
                            Status: (item.Status === true ? '<a href="#" class="badge badge-success btnStatus" data-id="' + item.ID + '">Activated</a>' : '<a href="#" class="badge badge-danger btnStatus" data-id="' + item.ID + '">Disabled</a>')
                        });
                    });
                    $("#tblUsers").html(html);
                    userController.registerEvent();
                }
            }
        });
    }
};

userController.init();