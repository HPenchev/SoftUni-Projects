(function() {
    function paint() {
        var $className = '.' + $('#class-name').val(),
            $color = $('#color').val();

        $($className).css('background-color', $color);
    }

    $('#paint').on('click', paint);
})();