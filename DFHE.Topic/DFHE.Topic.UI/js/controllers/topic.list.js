(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('TopicListCtrl', TopicListCtrl);

    function TopicListCtrl($scope) {
        this.scope = $scope;
        this._init();
    }

    TopicListCtrl.prototype = {
        _init: function () {
            this._setScope();
        },
        _setScope:function(){
            var _this = this;
            _this._registerMethod();
        },
        _registerMethod: function () {

        }
    }
})();