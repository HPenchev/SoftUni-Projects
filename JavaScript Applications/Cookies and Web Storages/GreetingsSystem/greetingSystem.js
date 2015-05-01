var greetingSystem = (function() {
    var name = localStorage.getItem('name'),
        totalVisits = localStorage.getItem('visits'),
        sessionVisits = sessionStorage.getItem('sessionVisits'),
        totalVisitsOutput,
        sessionVisitsOutput;

    function test() {
        alert('test');
    }

    function takeName() {
        var divElement = $(document.createElement('div'));

        $(document.body).append(
            '<div>Please enter your name:</div>',
            '<label for="name">Name: </label>',
            '<input id="name" type="text"/>',
            '<input id="btn" type="button" value="Submit"/>');
        $('#btn').on('click', function(event) {
            localStorage.setItem('name', $('#name').val());
            location.reload();
        });
    }

    if(name) {
        var greeting = '<div>Hello, ' + name + '</div>';
        $(document.body).append(greeting);
    } else {
        takeName();
    }

    if (totalVisits) {
        totalVisits ++;
    } else {
        totalVisits = 1;
    }

    totalVisitsOutput = '<br/>Total visits: <div>' + totalVisits + '</div>';
    localStorage.setItem('visits', totalVisits);
    $(document.body).append(totalVisitsOutput);

    if (sessionVisits) {
        sessionVisits ++;
    } else {
        sessionVisits = 1;
    }

    sessionVisitsOutput = 'Session visits: <div>' + sessionVisits + '</div>';
    sessionStorage.setItem('sessionVisits', sessionVisits);
    $(document.body).append(sessionVisitsOutput);
}());