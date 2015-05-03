(function () {
    'use strict';

    angular
        .module('Topic.dict',[])
        .factory("topicDict", function () {
            var reqDict = [
                { key: 1, value: '姓名' },
                { key: 2, value: '手机号码' },
                { key: 3, value: '年龄' },
                { key: 4, value: '性别' },
                { key: 5, value: '职业' },
                { key: 6, value: '教育程度' },
                { key: 7, value: '推荐人' },
                { key: 8, value: '所在地' },
                { key: 9, value: '婚姻状态' },
                { key: 10, value: '意见' }
            ];
            return {
                reqDict: reqDict
            };
        });
})();