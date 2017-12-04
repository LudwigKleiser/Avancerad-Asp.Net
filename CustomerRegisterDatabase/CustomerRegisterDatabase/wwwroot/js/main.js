function clear() {
    $("#successMessage").text("");
    $("#errorMessage").text("");
}

function remove(id) {
    $.ajax({
        url: '/api/Customers/removecustomer',
        method: 'POST',
        data: {
            id: id
        }

    })
        .done(function (result) {

            alert(`Success! Result = ${result}`);
            console.log("Success!", result);

        })

        .fail(function (xhr, status, error) {

            //alert(`Fail!`);
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

        })

        .fail(function (xhr, status, error) {

            //alert(`Fail!`);
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
            let contentString = '<table class="table"><thead><tr><th scope="col">Id</th><th scope="col">First Name</th><th scope="col">Last Name</th><th scope="col">Gender</th><th scope="col">Email</th><th scope="col">Age</th><th scope="col">Remove</tr></thead><tbody>';
            $.each(result, function (index, person) {
                contentString += '<tr><th scope="row">' + person.id + '</th > <td>' + person.firstName + '</td > <td>' + person.lastName + '</td > <td>' + person.gender + '</td > <td>' + person.email + '</td> <td>' + person.age + '</td >' + '<td> <button class="btn btn-warning" onclick="remove(' + person.id +')"</button> </td>  </ tr> ';
            });
            contentString += '</tbody></table>';
            $("#successMessage").html(contentString);

        })
        .fail(function (xhr, status, error) {

            console.log("Fail", xhr);
            clear();
            $("#errorMessage").text(xhr.responseText);

        });

});
