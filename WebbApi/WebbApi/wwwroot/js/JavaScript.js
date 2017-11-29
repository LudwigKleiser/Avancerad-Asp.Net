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
            $("#successMessage").text(result);

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
            $("#successMessage").text(result);

        })
        .fail(function (xhr, status, error) {

            console.log("Fail", xhr);
            clear();
            $("#errorMessage").text(xhr.responseText);

        });

});