var Person = (function() {
    function Person (name, jobTitle, website, id) {
        this.name = name;
        this.jobTitle = jobTitle;
        this.website = website;
        this.id = id;
    }

    return Person;
}());