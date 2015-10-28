$(document).ready(function() {
    $('#addPlayerForm').validate({
        rules: {
            PlayerName: {
                required: true,
                minlength: 2
            },
            JerseyNumber: {
                required: true,
                minlength: 1
            },
            PositionID: {
                required: true
            }
        },
        messages: {
            PlayerName: {
                required: "Who enters a nameless player, honestly?!",
                minlength: "Lets keep the names at least two letters."
            },
            JerseyNumber: "No one wants to be a zero...",
            PositionID: "Give the player a position!"
        }
    });
});