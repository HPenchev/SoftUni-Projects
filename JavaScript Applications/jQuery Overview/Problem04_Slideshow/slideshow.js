(function() {
    var urls = ['slideOne.html', 'slideTwo.html', 'slideThree.html', 'slideFour.html', 'slideFive.html'],
        urlToLoad = 0,
        _MIN_URL = 0,
        _MAX_URL = 4,
        timer = setInterval(function(){
            if (urlToLoad < _MAX_URL) {
                urlToLoad += 1;
                changeSlide(urlToLoad);
            }
        }, 5000);

    function changeSlide(index) {
        $('#container').load(urls[urlToLoad]);
    }

    changeSlide(urlToLoad);

    function test() {
        alert('test');
    }

    $('[type="button"]').on('click', function(event){
        if (event.target.id == 'next' && urlToLoad < _MAX_URL) {
            urlToLoad += 1;
        } else if (event.target.id == 'previous' && urlToLoad > _MIN_URL) {
            urlToLoad -= 1;
        }
        changeSlide(urlToLoad);
        clearInterval(timer);
        timer = setInterval(function(){
            if (urlToLoad < _MAX_URL) {
                urlToLoad += 1;
                changeSlide(urlToLoad);
            }
        }, 5000);
    });


})();