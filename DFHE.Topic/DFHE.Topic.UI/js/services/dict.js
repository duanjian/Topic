(function () {
    'use strict';

    angular
        .module('Topic.dict', [])
        .factory('topicDict', function () {
            //需填信息字典
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
            //模版类型字典
            var tplTypeDict = [
                { key: 1, value: '标签页型' },
                { key: 2, value: '滑动页型' }
            ];

            //模版颜色配置
            var colorDict = [
                { key: '#ffffff', value: 'light' },
                { key: '#f8f8f8', value: 'stable' },
                { key: '#387ef5', value: 'positive' },
                { key: '#11c1f3', value: 'calm' },
                { key: '#33cd5f', value: 'balanced' },
                { key: '#ffc900', value: 'energized' },
                { key: '#ef473a', value: 'assertive' },
                { key: '#886aea', value: 'royal' },
                { key: '#444444', value: 'dark' }
            ];

            //模版颜色字典
            var colorDict4Trans =
                {
                    '#ffffff': 'light',
                    '#f8f8f8': 'stable',
                    '#387ef5': 'positive',
                    '#11c1f3': 'calm',
                    '#33cd5f': 'balanced',
                    '#ffc900': 'energized',
                    '#ef473a': 'assertive',
                    '#886aea': 'royal',
                    '#444444': 'dark'
                };
            
            return {
                reqDict: reqDict,
                tplTypeDict: tplTypeDict,
                colorDict: colorDict,
                colorDict4Trans: colorDict4Trans
            };
        });
})();