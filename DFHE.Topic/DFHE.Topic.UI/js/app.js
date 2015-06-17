angular.module('Topic', ['ui.router', 'ngSanitize', 'ngAnimate', 'mgcrea.ngStrap', 'Topic.dict', 'Topic.net', 'summernote'])


.directive('onFinishRenderFilters',function ($timeout) {
    return {
        restrict: 'A',
        link: function(scope,element,attr) {
            if (scope.$last === true) {
                $timeout(function() {
                    scope.$emit('ngRepeatFinished');
                });
            }
        }
        };
});
