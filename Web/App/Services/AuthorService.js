app.service('AuthorService', function ($http) {

    this.getAll = function () {
        return $http.get(uri + '/api/author');
    };
    this.save = function (author) {
        return $http.post(uri + '/api/author', author);
    };

    this.update = function (author) {
        return $http.put(uri + '/api/author/' + author.id, author);
    };

    this.delete = function (author) {
        return $http.delete(uri + '/api/author/' + author.id);
    };
});