poll = poll || {}

var poll = (function(scope) {
    var score = 0,
        questions = {
            1: 'When did the Western Roman Empire fall?',
            2: 'Which year is officially accepted as a date of establishment of the First Bulgarian Empire?',
            3: 'Who considered to be the founder of America?',
            4: 'Where did Napoleon fight his final battle?',
            5: 'Which WWII battle is considered to be the bloodiest in world history?'
        },
        correctAnswers = {
            1: '476',
            2: '681',
            3: 'Christopher Columbus',
            4: 'Vaterlo',
            5: 'Battle of Stalingrad'
        },
        i;

    for (i = 1; i <=5; i+=1) {
        $('<div>' + questions[i] + '</div>').appendTo(document.body);
        $('<div>Answer: ' + correctAnswers[i] + '</div>').appendTo(document.body);
        $('<div>Your Answer: ' + localStorage.getItem(i) + '</div>').appendTo(document.body);
        $('<br/>').appendTo(document.body).appendTo(document.body);
        if (correctAnswers[i] == localStorage.getItem(i)) {
            score ++;
        }
    }

    $('<div>Score: ' + score + '</div>').appendTo(document.body);
})(poll)