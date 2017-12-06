function clear() {
    $("#successMessage").text("");
    $("#errorMessage").text("");
}

function remove(id) {
    $.ajax({
        url: '/api/Customers/removecustomer',
        method: 'POST',
        data: {
            id: this.id
        }

    })
        .done(function (result) {

            alert(`Success! Result = ${result}`);
            console.log("Success!", result);
            $("#ajaxAll").click();

        })

        .fail(function (xhr, status, error) {

            alert(`Fail!`);
            console.log("Error", xhr, status, error);

        });
}

$("#addForm button").click(function () {

    $.ajax({
        url: '/api/Customers/addcustomer',
        method: 'POST',
        data: {
            "FirstName": $("#addForm [name=FirstName]").val(),
            "LastName": $("#addForm [name=LastName]").val(),
            "Age": $("#addForm [name=Age]").val(),
            "Email": $("#addForm [name=Email]").val(),
            "Gender": $("#addForm [name=Gender]").val()
        }

    })
        .done(function (result) {

            alert(`Success! Result = ${result}`);
            console.log("Success!", result);
            $("#ajaxAll").click();

        })

        .fail(function (xhr, status, error) {

            alert(`Fail!`);
            console.log("Error", xhr, status, error);

        });
});


$("#ajaxAll").click(function () {



    $.ajax({
        url: 'api/customers/allcustomers',
        method: 'GET',
        data: {

        }
    })
        .done(function (result) {

            console.log("Success!", result);
            clear();
            let contentString = '<table class="table"><thead><tr><th scope="col">Id</th><th scope="col">First Name</th><th scope="col">Last Name</th><th scope="col">Gender</th><th scope="col">Email</th><th scope="col">Age</th><th scope="col">Remove</th><th scope="col">Edit</th></tr></thead><tbody>';
            $.each(result, function (index, person) {
                contentString += '<tr><th scope="row">' + person.id + '</th > <td>' + person.firstName + '</td > <td>' + person.lastName + '</td > <td>' + person.gender + '</td > <td>' + person.email + '</td> <td>' + person.age + '</td >' + '<td> <button id="' + person.id + '" class="btn btn-danger remove" > Delete  </button > </td > <td> <button id="' + person.id + '"' + 'class="btn btn-warning edit"> Edit </button>  </td >  </ tr > ';
            });
            contentString += '</tbody></table>';
            $("#successMessage").html(contentString);

            $(".remove").click(function () {

                $.ajax({
                    url: 'api/customers/removecustomer',
                    method: 'POST',
                    data: {
                        id: this.id
                    }
                })
                    .done(function (result) {

                        console.log("Success!", result);
                        $("#ajaxAll").click();
                        clear();

                    })
                    .fail(function (xhr, status, error) {

                        console.log("Fail", xhr);
                        clear();
                        $("#errorMessage").text(xhr.responseText);

                    });

            });
            $(".edit").click(function () {

                $.ajax({
                    url: 'api/customers/editcustomer',
                    method: 'GET',
                    data: {
                        id: this.id
                    }
                })
                    .done(function (result) {

                        console.log("Success!", result);
                        clear();
                        let modalString = '<div class="modal-dialog" role="document"><div class="modal-content"><div class="modal-header"><h5 class="modal-title">Edit</h5><button type="button" class="close" data-dismiss="modal" aria-label="Close">';
                        modalString += '<span aria-hidden="true">&times;</span ></button></div><div class="modal-body">';
                        modalString += '<div id="editForm">';
                        modalString += '<label> Förnamn</label >';
                        modalString += '<input value="' + result.firstName + '"' + ' name= "FirstName" /> </br>';
                        modalString += '<label>Efternamn</label>';
                        modalString += '<input value="' + result.lastName + '"' + ' name="LastName" /> </br>';
                        modalString += '<label>Ålder</label>';
                        modalString += '<input value="' + result.age + '"' + ' name="Age" /> </br>'
                        modalString += '<label>Email</label>';
                        modalString += '<input value="' + result.email + '"' + ' name="Email" /></br> ';
                        modalString += '<label>Kön</label>';
                        modalString += '<input value="' + result.gender + '"' + ' name="Gender" /> </br>';

                        modalString += '</div><div class="modal-footer">';
                        modalString += '<button type="button" id="saveEdit" class="btn btn-primary">Save changes</button><button type="button" id="testClose" class="btn btn-secondary" data-dismiss="modal">Close</button></div></div></div></div>';

                        $("#editMessage").html(modalString);
                        $("#editMessage").modal("show");
                        $("#testClose").click(function () {
                            $("#ajaxAll").click();
                        });

                        $("#saveEdit").click(function () {

                            $.ajax({
                                url: '/api/Customers/editcustomer',
                                method: 'POST',
                                data: {
                                    id: result.id,
                                    "FirstName": $("#editForm [name=FirstName]").val(),
                                    "LastName": $("#editForm [name=LastName]").val(),
                                    "Age": $("#editForm [name=Age]").val(),
                                    "Email": $("#editForm [name=Email]").val(),
                                    "Gender": $("#editForm [name=Gender]").val(),
                                    "Id": $("#editForm [name=Id]").val()
                                }

                            })
                                .done(function (result) {

                                    alert(`Success! Result = ${result}`);
                                    console.log("Success!", result);
                                    $("#ajaxAll").click();

                                })

                                .fail(function (xhr, status, error) {

                                    alert(`Fail!`);
                                    console.log("Error", xhr, status, error);

                                });
                        });


                    })
                    .fail(function (xhr, status, error) {

                        console.log("Fail", xhr);
                        clear();
                        $("#errorMessage").text(xhr.responseText);

                    });
            });

        });
});
