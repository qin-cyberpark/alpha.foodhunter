/// <binding />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    less = require("gulp-less"),
    uglify = require("gulp-uglify");



var contentPath = "./Content/";
var lessGroups = [{ src: "less/customer/*.less", dest: "css/customer" }];
var jsGroups = [{ src: "js/customer/**/*.js", exclude: "js/customer/**/*.min.js", dest: "dist/js/site-customer.min.js" },
                  { src: "js/counter/**/*.js", exclude: "js/counter/**/*.min.js", dest: "dist/js/site-counter.min.js" }];

var cssGroups = [{ src: "css/customer/*.css", exclude: "css/customer/*.min.css", dest: "dist/css/site-customer.min.css" },
                  { src: "css/counter/*.css", exclude: "css/counter/*.min.css", dest: "dist/css/site-counter.min.css" }];

/*clean*/
gulp.task("clean:css", function (cb) {
    rimraf(contentPath + "css/customer/*", cb);
});
gulp.task("clean:dist", function (cb) {
    rimraf(contentPath + "dist/*", cb);
});
gulp.task("clean", ["clean:css", "clean:dist"]);


/*less*/
gulp.task("less", function () {
    for (var i = 0; i < lessGroups.length; i++) {
        gulp.src(contentPath + lessGroups[i].src)
                .pipe(less())
                .pipe(gulp.dest(contentPath + lessGroups[i].dest));
    }
});

/*minify*/
gulp.task("min:js", function () {
    for (var i = 0; i < jsGroups.length; i++) {
        gulp.src([contentPath + jsGroups[i].src, "!" + contentPath + jsGroups[i].exclude])
                .pipe(concat(contentPath + jsGroups[i].dest))
                .pipe(uglify())
                .pipe(gulp.dest("."));
    }
});

gulp.task("min:map-js", function () {
    gulp.src([contentPath + '/js/store-map/*.js'])
            .pipe(uglify())
            .pipe(gulp.dest(contentPath +  '/dist/js/store-map'));
});



gulp.task("min:css", function () {
    for (var i = 0; i < cssGroups.length; i++) {
        gulp.src([contentPath + cssGroups[i].src, "!" + contentPath + cssGroups[i].exclude])
                .pipe(concat(contentPath + cssGroups[i].dest))
                .pipe(cssmin())
                .pipe(gulp.dest("."));
    }
});

gulp.task("min", ["min:map-js","min:js", "min:css"]);