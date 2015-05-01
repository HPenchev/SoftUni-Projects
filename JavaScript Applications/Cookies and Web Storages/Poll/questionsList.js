poll = poll || {}

var poll = (function(scope) {
    var name,
        userAnswer;
    $.each(localStorage, function(question, answer){
        console.log(question + '' + answer);
        name = '[name=' + question + '1]';

        $('[name=' + question + ']').filter('[value=' + answer + ']').prop('checked', true);
    });

    $('[type=radio]').on('change', function(event) {
        var question = $(this).attr('name'),
            answer = $(this).val();

       localStorage.setItem(question, answer);
    });

    $('#submit').on('click', function() {
        localStorage.setItem('isSubmitted', true);
        location.reload();
    });
})(poll)