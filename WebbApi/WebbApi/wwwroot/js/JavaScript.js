function clear() {
    $("#successMessage").text("");
    $("#errorMessage").text("");
}

$("#ajaxSingle").click(function () {

    let i = $("#input").val();
    let n = $("#check").prop("checked");
    console.log(n);
    $.ajax({
        url: 'api/demo5/FindPerson',
        method: 'GET',
        data: {
            id: i,
            brief: n
        }
    })
        .done(function (result) {

            console.log("Success!", result);
            clear();
            let contentString = '<table class="table"><thead><tr><th scope="col">Id</th><th scope="col">First Name</th><th scope="col">Last Name</th><th scope="col">Gender</th><th scope="col">Email</th><th scope="col">Age</th></tr></thead><tbody>';
            contentString += '<tr><th scope="row">' + result.id + '</th > <td>' + result.firstname + '</td > <td>' + result.lastname + '</td > <td>' + result.gender + '</td > <td>' + result.email + '</td> <td>' + result.age+'</td ></tr > ';
                //    <tr>
                //        <th scope="row">2</th>
                //        <td>Jacob</td>
                //        <td>Thornton</td>
                //        <td>@fat</td>
                //    </tr>
                //    <tr>
                //        <th scope="row">3</th>
                //        <td>Larry</td>
                //        <td>the Bird</td>
                //        <td>@twitter</td>
                //</tr>
            contentString += '</tbody></table>';

            $("#successMessage").html(contentString);

        })
        .fail(function (xhr, status, error) {

            console.log("Fail", xhr);
            clear();
            $("#errorMessage").text(xhr.responseText);

        });

});

$("#ajaxAll").click(function () {

    
    
    $.ajax({
        url: 'api/demo5/GetAllPersons',
        method: 'GET',
        data: {
          
        }
    })
        .done(function (result) {

            console.log("Success!", result);
            clear();
            let contentString = '<table class="table"><thead><tr><th scope="col">Id</th><th scope="col">First Name</th><th scope="col">Last Name</th><th scope="col">Gender</th><th scope="col">Email</th><th scope="col">Age</th></tr></thead><tbody>';
            $.each(result, function (index, person) {
                contentString += '<tr><th scope="row">' + person.id + '</th > <td>' + person.firstname + '</td > <td>' + person.lastname + '</td > <td>' + person.gender + '</td > <td>' + person.email + '</td> <td>' + person.age + '</td ></tr > ';
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