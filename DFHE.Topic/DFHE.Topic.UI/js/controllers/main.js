(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('MainCtrl', MainCtrl);

    function MainCtrl($scope, delay) {
        this.scope = $scope;
        this.delay = delay;
        this._init();
    }

    MainCtrl.prototype = {
        _init: function () {
            this._setScope();
        },
        _setScope: function () {
            var _this = this;
            _this._registerMethod();
        },
        _registerMethod: function () {
            var _this = this;
        }
    }
})();