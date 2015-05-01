var app = app || {};

app.peopleView = (function() {
    function PeopleView(selector, data) {
        $(selector).empty();

        $.get('templates/people.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).append(output);
        });
    }

    return {
        load: function (selector, data) {
            new PeopleView(selector, data);
        }
    }
}());