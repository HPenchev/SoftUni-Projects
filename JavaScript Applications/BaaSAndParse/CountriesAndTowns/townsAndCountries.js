(function (){
    var $list = $('<ul id="countries"/>');
    function printCountries(countries) {
            var $addCountryField = $('<input type="text", id="new-country-name"/>'),
            $submitNewCountry = $('<input type="button", id="addCountry", value="Add New Country"/>')
                .on('click', function () {
                    var country = $('#new-country-name').val();
                    addCountry(country);
                    $('#new-country-name').val('');
                }),
            name,
            id,
            $deleteButton,
            $editButton;

        for (var number in countries.results) {
            name = countries.results[number].name;
            id = countries.results[number].objectId;
            addCountryToList(name, id);
        }

        $(document.body).append($list).append($addCountryField).append($submitNewCountry);
    }

    function deleteCountry(element) {
        var id = $(element).attr('id');
        $.ajax({
            method: 'DELETE',
            headers: {
                'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
            },
            url: 'https://api.parse.com/1/classes/Country/' + id
        }).success(function() {
            $(element).remove();
        }). error(function(err) {
            console.log(err.response)
        })
    }

    function editCountry(country) {
        var id = $(country).attr('id'),
            $input,
            $button;

        if ($(country).find('[type="text"]').length) {
            return;
        }

        $input = $('<br><span>Name: </span><input type="text"/>');
        $button = $('<input type="button", value="Update Name">')
            .on('click', function () {
                var name = $(country).find('[type="text"]').val();
                $.ajax({
                    method: 'PUT',
                    headers: {
                        'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                        'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                    },
                    url: 'https://api.parse.com/1/classes/Country/' + id,
                    data: JSON.stringify({
                        'name': name
                    })

                }).success(function() {
                    $(country).find('.country-name').text(name);
                    $input.remove();
                    $button.remove();
                }). error(function(err) {
                    console.log(err.response)
                })
            });
        $(country).append($input).append($button);
    }

    function addCountry(country) {
        $.ajax({
            method: 'POST',
            headers: {
                'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
            },
            url: 'https://api.parse.com/1/classes/Country',
            data: JSON.stringify({
                'name': country
            })

        }).success(function() {
            addCountryToList(country);
        }). error(function(err) {
            console.log(err.response)
        })
    }

    function getCountryId(name) {
        return $.ajax({
            method: 'GET',
            headers: {
                'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
            },
            url: 'https://api.parse.com/1/classes/Country',
            data: {
                keys: 'objectID',

                where: {
                    'name': name
                }
            }
        })
    }

    function addCountryToList(name, id) {
        var $country,
            $deleteButton,
            $editButton;

        if(!id) {
            getCountryId(name).
                success(function(data) {
                for (num in data.results) {
                    id = data.results[num]['objectId'];
                }

                addCountryToDOM();
            }). error(function(err) {
                console.log(err.response)
            })
        } else {
            addCountryToDOM();
        }

        function addCountryToDOM() {
            var $nameDiv = $('<div class="country-name">' + name + '</div>').on('click', function() {
                loadTowns($(event.target).parent());
            });
            $deleteButton = $('<input type="button" value="Delete Country"/>').on('click', function () {
                deleteCountry($(event.target).parent());
            });
            $editButton = $('<input type="button" value="Edit Country"/>').on('click', function () {
                editCountry($(event.target).parent());
            });
            $country = $('<li id="' + id + '"> </li>');
            $country.append($nameDiv).append($deleteButton).append($editButton);
            $list.append($country);
        }
    }

    function loadTowns(li) {
        var id = $(li).attr('id'),
            //country = getCountryById(id);
            townsUl = $(li).find('.town-container');

        //alert(country['name']);

        if (townsUl.length > 0) {
            townsUl = townsUl[0];
            $(townsUl).remove();
            return;
        }

        $.ajax({
            method: 'GET',
            headers: {
                'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
            },
            url: 'https://api.parse.com/1/classes/Town',
            data: {
                where: {
                    'country':{'__type':'Pointer','className':'Country','objectId':id}
                }
            }
        }).success(function(data) {
            addTownsToDOM(li, data.results);
        }). error(function(err) {
            console.log(err.response)
        })
    }

    function addTownsToDOM(country, towns) {
        var $townContainer = $('<div class="town-container"></div>'),
            $townList = $('<ul>'),
            $addTownButton = $('<input type="button", value="Add Town"/>').on('click', function() {
                var li = $($(event.target).parent()).parent(),
                    countryId = $(li).attr('id'),
                    container = $(li).find('.town-container'),
                    newTownName = $(container).find('[type="text"]').val(),
                    newTownId;

                $.ajax({
                    method: 'POST',
                    headers: {
                        'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                        'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                    },
                    url: 'https://api.parse.com/1/classes/Town',
                    data: JSON.stringify({
                        'name': newTownName,
                        'country':{'__type':'Pointer','className':'Country','objectId':countryId}
                    })

                }).success(function() {
                    $.ajax({
                        method: 'GET',
                        headers: {
                            'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                            'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                        },
                        url: 'https://api.parse.com/1/classes/Town',
                        data: {
                            keys: 'objectID',

                            where: {
                                'name': newTownName
                            }
                        }
                    }).success(function(data) {
                        for (num in data.results) {
                            newTownId = data.results[num]['objectId'];
                        }

                        addTownToDOM(newTownName, newTownId)
                    }). error(function(err) {
                        console.log(err.response)
                    })
                    $(container).find('[type="text"]').val('');
                }). error(function(err) {
                    console.log(err.response)
                })
            }),
            editButton,
            deleteButton,
            townName,
            townId,
            town;

        function addTownToDOM(townName, townId) {
            editButton = $('<input type="button", value="Edit Town"/>').on('click', function() {
                var editTown = $(event.target).parent(),
                    editTownId = $(editTown).attr('id'),
                    editTownSection = $('<div class="edit-town-section">'),
                    newNameInput = $('<input type="text" class="new-name-input"/>'),
                    newNameButton = $('<input type="button", value="Update Town Name">').on('click', function () {
                        var updatedTownName = $(event.target).parent().find('.new-name-input').val();

                        $.ajax({
                            method: 'PUT',
                            headers: {
                                'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                                'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                            },
                            url: 'https://api.parse.com/1/classes/Town/' + editTownId,
                            data: JSON.stringify({
                                'name': updatedTownName
                            })

                        }).success(function() {
                            $('#' + editTownId).find('.town-name').text(updatedTownName);
                            $(editTownSection).remove();
                        }). error(function(err) {
                            console.log(err.response)
                        })
                    }),
                    newCountryInput = $('<input type="text" class="new-country-input"/>'),
                    newCountryButton = $('<input type="button", value="Update Town Country">').on('click', function() {
                        var updatedTownCountry = $(event.target).parent().find('.new-country-input').val(),
                            newCountryId;

                        getCountryId(updatedTownCountry)
                            .success(function(data) {
                                for (num in data.results) {
                                    newCountryId = data.results[num]['objectId'];
                                }

                                $.ajax({
                                    method: 'PUT',
                                    headers: {
                                        'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                                        'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                                    },
                                    url: 'https://api.parse.com/1/classes/Town/' + editTownId,
                                    data: JSON.stringify({
                                        'country':{'__type':'Pointer','className':'Country','objectId':newCountryId}
                                    })

                                }).success(function() {
                                    $('#' + editTownId).remove();
                                }). error(function(err) {
                                    console.log(err.response)
                                })
                            }). error(function(err) {
                                console.log(err.response)
                            })
                    });

                $(editTownSection)
                    .append(newNameInput)
                    .append(newNameButton)
                    .append('<br/>')
                    .append(newCountryInput)
                    .append(newCountryButton);

                if($(editTown).find('.edit-town-section').length > 0) {
                    return;
                }

                $(editTown).append(editTownSection);
            });
            deleteButton = $('<input type="button", value="Delete Town"/>').on('click', function() {
                var deleteTown = $(event.target).parent(),
                    deleteTownId = $(deleteTown).attr('id');

                $.ajax({
                    method: 'DELETE',
                    headers: {
                        'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
                        'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
                    },
                    url: 'https://api.parse.com/1/classes/Town/' + deleteTownId
                }).success(function() {
                    $(deleteTown).remove();
                }). error(function(err) {
                    console.log(err.response)
                })
            });

            town = $('<li id="' + townId + '"><span class="town-name">' + townName + '</span></li>');
            town.append(editButton).append(deleteButton);
            $townList.append(town);
        }

        for(index in towns) {
            townName = towns[index]['name'];
            townId = towns[index]['objectId'];
            addTownToDOM(townName, townId);
        }

        $townContainer
            .append($townList)
            .append('<input type="text",class="town-name"/>')
            .append($addTownButton);

        $(country).append($townContainer);
    }

    $.ajax({
        method: 'GET',
        headers: {
            'X-Parse-Application-Id': 'OJpsCHALeoLwNrj6NYtrcsWFM9JrRTo8bqylChQ1',
            'X-Parse-REST-API-Key': 'drIhdwtrjxVb73nYNzNlcQWQwDx0wpxNu9Hswu4g'
        },
        url: 'https://api.parse.com/1/classes/Country'

    }).success(function(data) {
        printCountries(data);
    }). error(function(err) {
        console.log(err.response)
    });
})();