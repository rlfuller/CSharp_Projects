$(document).ready(function () {
    $('#addTeamForm').validate({
        rules: {
            TeamName: {
                required: true,
                minlength: 2
            },
            ManagerName: {
                required: true,
                minlength: 2
            }
        },
        messages: {
            TeamName: {
                required: "Who enters a nameless team, honestly?!",
                minlength: "Lets keep the names at least two letters."
            },
            ManagerName: {
                required: "Who enters a nameless manager, honestly?!",
                minlength: "Lets keep the names at least two letters."
            }
        }
    });
});