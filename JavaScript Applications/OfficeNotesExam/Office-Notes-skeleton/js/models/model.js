var app = app || {};

app.model = (function() {
    function Model(baseUrl, requester, headers) {
        this.baseUrl = baseUrl;
        this.requester = requester;
        this.headers = headers;
    }

    function stringifyDate(date) {
        var day = ("0" + date.getDate()).slice(-2);
        var month = ("0" + (date.getMonth() + 1)).slice(-2);
        var year = date.getFullYear();
        var formattedDate = day + '/' + month + '/' + year;
        return formattedDate;
    }

    Model.prototype.login = function(username, password) {
        var serviceUrl = this.baseUrl + 'login?username=' + username + '&password=' + password;
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    Model.prototype.register = function(username, password, fullName) {
        var serviceUrl = this.baseUrl + 'users/';
        var data = {
            username: username,
            password: password,
            fullName: fullName
        };
        return this.requester.post(serviceUrl, this.headers.getHeaders(), data);
    };

    Model.prototype.logout = function() {
        var serviceUrl = this.baseUrl + 'logout';
        return this.requester.post(serviceUrl, this.headers.getHeaders(true));
    };

    Model.prototype.loadNotesForToday = function(skipped) {
        var formattedDate = stringifyDate(new Date()),
            serviceUrl =
                this.baseUrl +
                "classes/Note" +
                '?where={"deadline":"' + formattedDate + '"}' +
                '&include=author' +
                '&count=1&limit=10&skip=' +
                skipped;
            ;
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    Model.prototype.loadMyNotes = function(skipped) {
        skipped = parseInt(skipped);
        var serviceUrl =
            this.baseUrl +
            "classes/Note" +
            '?where={"author":{"__type":"Pointer","className":"_User","objectId":"' +
            sessionStorage['userId'] +
            '"}}' +
            '&include=author&count=1&limit=10&skip=' +
            skipped;
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    Model.prototype.takeNote = function(noteId) {
        var serviceUrl = this.baseUrl + "classes/Note/" + noteId;
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    Model.prototype.addNote = function(title, text, date) {
        var userId = sessionStorage['userId'],
            serviceUrl = this.baseUrl + "classes/Note",
            formattedDate = stringifyDate(date),
            data = {
                title: title,
                text: text,
                deadline: formattedDate,
                author: {"__type":"Pointer","className":"_User","objectId": userId},
                ACL : {}
            };

        data.ACL[userId] = {"write":true,"read":true};
        data.ACL["*"] = {"read":true};

        return this.requester.post(this.baseUrl + 'classes/Note', this.headers.getHeaders(), data);
    };

    Model.prototype.editNote = function(noteId, title, text, date) {
        var serviceUrl = this.baseUrl + "classes/Note/" + noteId,
            date = stringifyDate(date),
            data = {
                title: title,
                text: text,
                date: date
            };

        return this.requester.put(serviceUrl, this.headers.getHeaders(true), data);
    };

    Model.prototype.deleteNote = function(noteId) {
        return this.requester.remove(this.baseUrl + "classes/Note/" + noteId, this.headers.getHeaders(true));
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new Model(baseUrl, requester, headers);
        }
    }
}());