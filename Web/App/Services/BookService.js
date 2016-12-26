app.service('BookService', function ($http) {

    this.getAll = function () {
        return $http.get(uri + '/api/book');
    };

    this.save = function (book) {
        return $http.post(uri + '/api/book', book);
    };

    this.update = function (book) {
        return $http.put(uri + '/api/book/' + book.id, book);
    };

    this.delete = function (book) {
        return $http.delete(uri + '/api/book/' + book.id);
    };

});