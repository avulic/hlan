/// <binding />
"use strict";
var path = require("path");
var WebpackNotifierPlugin = require("webpack-notifier");
var BrowserSyncPlugin = require("browser-sync-webpack-plugin");
var HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: ['babel-polyfill', "./src/index.js"],
    output: {
        path: path.resolve(__dirname, "./dist"),
        filename: "bundle.js",
        publicPath: '/'
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            }
        ]
    },
    devtool: "inline-source-map",
    devServer: {
        historyApiFallback: true,
    },
    plugins: [
        new WebpackNotifierPlugin(), 
        new BrowserSyncPlugin(),
        new HtmlWebpackPlugin({
            template: './src/index.html'
        })
    ],
    resolve: {
        extensions: ['.js', '.jsx'],
        alias: {
            '@': path.resolve(__dirname, './src'),
            '@assets': path.resolve(__dirname, './src/components'),
            '@components': path.resolve(__dirname, './src/components'),
            '@views': path.resolve(__dirname, './src/views'),
            '@utils': path.resolve(__dirname, './src/utils')
        },
    }
};