var app = app || {};

app.controller = (function() {
    function Controller(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    function successNoty(text) {
        var n = noty({
            type: 'success',
            text: text,
            layout: 'bottomCenter',
            timeout: 2000
        });
        n.close();
    }

    function errorNoty(text) {
        var n = noty({
            type: 'error',
            text: text,
            layout: 'bottomCenter',
            closeWith: ['button'],
            timeout: 4000});
        n.close();
    }
    //
    //Controller.prototype.loadMenu = function(selector) {
    //    var userId = sessionStorage['userId'];
    //    if(userId) {
    //        this.viewBag.loadUserMenu(selector);
    //    } else {
    //        this.viewBag.loadGuestMenu(selector);
    //    }
    //};
    //
    Controller.prototype.loadWelcomeGuestScreen = function(selector) {
        this.viewBag.loadWelcomeGuestScreen(selector);
    };

    Controller.prototype.loadRegisterForm = function(selector) {
        var _this = this;
        this.viewBag.loadRegisterForm(_this, selector);
    };

    Controller.prototype.loadLoginForm = function(selector) {
        var _this = this;
        this.viewBag.loadLoginForm(_this, selector);
    };

    Controller.prototype.loadUserHomePage = function(selector) {
        var data = {
                name: sessionStorage['fullName'],
                username: sessionStorage['username']
                }

        this.viewBag.loadUserHomePage(selector, data);
    };

    Controller.prototype.loadAddNoteForm = function(selector) {
        var _this = this;
        this.viewBag.displayAddNoteForm(_this, selector);
    };

    Controller.prototype.loadEditNoteForm = function(selector, noteId) {
        var _this = this;
        var _viewBag = this.viewBag;
        return this.model.takeNote(noteId)
            .then(function(data) {
                _viewBag.loadEditNoteForm(_this, selector, data);
            }, function(error) {
                errorNoty("An error occured. Please try again later\n" + error.responseText);
            });
    };

    Controller.prototype.loadDeleteNoteForm = function(selector, noteId) {
        var _this = this;
        var _viewBag = this.viewBag;
        return this.model.takeNote(noteId)
            .then(function(data) {
                _viewBag.loadDeleteNoteForm(_this, selector, data);
            }, function(error) {
                errorNoty(error.responseText);
            });
    };

    Controller.prototype.login = function(username, password) {
        return this.model.login(username, password)
            .then(function(loginData) {
                console.log(loginData);
                successNoty("Login successful");
                setUserToStorage(username, loginData.objectId, loginData.fullName, loginData.sessionToken);
                window.location.replace('#/home/');

            }, function(error) {
                console.log(error.responseText);
                errorNoty("An error occured. Please try again later. \n" + error.responseText);
                window.location.replace('#/login/');
            })
    };

    Controller.prototype.register = function(username, pass, fullName) {

        return this.model.register(username, pass, fullName)
            .then(function (registerData) {
                successNoty("Registration successful");
                setUserToStorage(username, registerData.objectId, fullName, registerData.sessionToken);
                window.location.replace('#/home/');
            }, function (error) {
                errorNoty('An error occured during registration. Please try again later \n' + error.responseText);
                window.location.replace('#/register/');
            })
    };

    Controller.prototype.logout = function() {
        return this.model.logout()
            .then(function() {
                clearUserFromStorage();
                window.location.replace('#/');
                successNoty("successful logout");
            }, function(error) {
                errorNoty(error.responseText);
            });

    };

    function setUserToStorage(username, userId, fullName, sessionToken) {
        sessionStorage['username'] = username;
        sessionStorage['userId'] = userId;
        sessionStorage['fullName'] = fullName;
        sessionStorage['sessionToken'] = sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['sessionToken'];
        delete sessionStorage['fullName']
    }

    Controller.prototype.loadNotesForToday = function (selector, skipped) {
        var _this = this;
        return this.model.loadNotesForToday(skipped)
            .then(function (data) {
                _this.viewBag.listAllNotesForToday(selector, data);
            }, function (error) {
                errorNoty('An error occurred loading office notes. Please try again later. \n' + error.responseText);
            })
    };

    Controller.prototype.loadMyNotes = function (selector, skipped) {
        var _this = this;
        return this.model.loadMyNotes(skipped)
            .then(function (data) {
                //console.log(data);
                _this.viewBag.listAllMyNotes(selector, data);
            }, function (error) {
                errorNoty('An error occurred loading your notes. Please try again later. \n' + error.responseText);
            })
    };

    Controller.prototype.addNote = function (title, text, date) {
        this.model.addNote(title, text, date)
                .then(function (data) {
                    console.log(data);
                    successNoty("Note successfully added")
                    window.location.replace('#/myNotes/');
                }, function (error) {
                    errorNoty("An error occurred adding the note. Please try again later.\n" + error.responseText);
                })
        };

    Controller.prototype.deleteNote = function (noteId) {
        return this.model.deleteNote(noteId)
            .then(function(data) {
                successNoty("Note successfully deleted")
                window.location.replace('#/myNotes/');
            }, function(error) {
                errorNoty(error.responseText);
            })
    };

    Controller.prototype.editNote = function (noteId, title, text, deadline) {

        return this.model.editNote(noteId, title, text, deadline)
            .then(function (data) {
                successNoty("Note successfully edited")
                console.log(data);
                window.location.replace('#/myNotes/');
            }, function (error) {
                errorNoty(error.responseText);
            })

    };

    return {
        load : function(model, views) {
            return new Controller(model, views);
        }
    }
}());