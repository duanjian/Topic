(function () {
    'use strict';

    angular
		.module('Topic')
		.config(function ($stateProvider, $urlRouterProvider) {
		    $stateProvider
				.state('signin', {
				    url: '/signin',
				    templateUrl: 'templates/signin.tpl.html',
				    controller: 'SignInCtrl'
				})
				.state('main', {
				    url: '/main',
				    abstract: true,
				    templateUrl: 'templates/main.tpl.html',
				    controller: 'MainCtrl',
				    resolve: {
				        delay: function ($q) {
				            var delay = $q.defer(),
                            load = function () {
                                $.getScript('/assets/javascripts/jquery-1.11.2.js', function () {
                                    delay.resolve();
                                });
                                $.getScript('/assets/javascripts/pixel-admin.min.js', function () {
                                    delay.resolve();
                                });
                            };
				            load();
				            return delay.promise;
				        }
				    }
				})
                .state('main.topiclist', {
                    url: '/topiclist',
                    views: {
                        'content': {
                            templateUrl: 'templates/topic.list.tpl.html',
                            controller: 'TopicListCtrl'
                        }
                    }
                })
                .state('main.createtopics', {
                    url: '/createtopics',
                    views: {
                        'content': {
                            templateUrl: 'templates/topic.create.tpl.html',
                            controller: 'TopicCreateCtrl'
                        }
                    }
                });

		    $urlRouterProvider.otherwise('/main/topiclist');
		})
})();