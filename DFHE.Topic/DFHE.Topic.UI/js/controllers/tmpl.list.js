(function() {
    'use strict';

    angular
        .module('Topic')
        .controller('TmplListCtrl', TmplListCtrl);

    function TmplListCtrl($scope) {
        this.scope = $scope;
        this._init();
    }

    TmplListCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope:function() {
            var _this = this;
            _this._registerMethod();
        },
        _registerMethod:function() {
            
        }
    }


})();