(function() {
    function createTable(text) {
        var $arr = $.parseJSON(text),
            $table = $('<table><thead><tr><th>Manufacturer</th><th>Model</th><th>Year</th>' +
            '<th>Price</th><th>Class</th></tr></thead><tbody></tbody></table>');

        $.each($arr, function(index, value) {
            $table.
                find('tbody').
                append('<tr><td>' + value.manufacturer + '</td>' +
                '<td>' + value.model + '</td>' +
                '<td>' + value.year + '</td>' +
                '<td>' + value.price + '</td>' +
                '<td>' + value.class + '</td></tr>');
        });

        $table.appendTo(document.body);
    }

    createTable('[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
    ' {"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
    '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]'
    )
})();