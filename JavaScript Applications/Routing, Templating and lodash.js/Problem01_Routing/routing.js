var app = app || {};
//console.log(app);
(function (app) {
    app.router = Sammy(function () {
        var selector = $('#name');

        this.get('#/Pesho', function() {
            $(selector).html('Pesho');
        });

        this.get('#/Gosho', function() {
            $(selector).html('Gosho');
        });

        this.get('#/Mariika', function() {
            $(selector).html('Mariika');
        });
    });

    app.router.run('#/');
}(app));
//console.log(app);