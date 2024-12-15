<script>
function UpdateInputWidth() {
    var inputs = document.querySelectorAll('input[type="text"]');
    inputs.forEach(function(input) {
        input.style.width = (input.value.length + 1) + 'ch';
    });
}

document.addEventListener('DOMContentLoaded', function() {
    UpdateInputWidth();
});

window.domInterop = {
    updateInputWidth: function (shelfId) {
        var inputElement = document.getElementById('shelf-' + shelfId);
        if (inputElement) {
            inputElement.style.width = (inputElement.value.length + 1) + 'ch';
        }
    }
};

</script>
