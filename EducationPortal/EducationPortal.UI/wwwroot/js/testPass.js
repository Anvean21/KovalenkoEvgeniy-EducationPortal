
function TestPassing() {
    var cshtmlURL = document.getElementById("urlId").innerHTML;
    var testId = document.getElementById("testId").innerHTML;
    var inputs = document.querySelectorAll('input:checked');

    var results = [];
    Array.from(inputs).forEach(function (item) {
        results.push(document.getElementById(item.id).value);
    });

    var result = results.join(",")
    $.ajax({
        type: "Get",
        url: cshtmlURL,
        data: { results: result, testId: testId },
        contentType: "html",
        cache: false,
        async: true
    });
}