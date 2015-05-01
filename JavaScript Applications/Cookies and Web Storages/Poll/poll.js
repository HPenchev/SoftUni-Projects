poll = poll || {}

var poll = (function(scope) {
    if(!localStorage.getItem('isSubmitted')) {
        $('#container').load('questions.html');
    } else {
        $('#container').load('results.html');
    }
})(poll)