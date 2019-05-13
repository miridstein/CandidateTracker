$(() => {
    $("#confirm-button").on('click', function () {
        console.log("hello");
        const id = $("#candidateId").val();
        $.post('/home/confirmcandidate', { id }, function () {
            $("#confirm-button").hide();
            $("#decline-button").hide();
        });
    });
    $("#decline-button").on('click', function () {
        console.log("hello");
        const id = $("#candidateId").val();
        $.post('/home/declinecandidate', { id }, function () {
            $("#confirm-button").hide();
            $("#decline-button").hide();
        });
    });
})