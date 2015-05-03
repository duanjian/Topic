(function () {
    'use strict';

    angular
        .module('Topic')
        .controller('SignInCtrl', SignInCtrl);

    function SignInCtrl($scope) {
        this.scope = $scope;
        this._init();
    }

    SignInCtrl.prototype = {
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