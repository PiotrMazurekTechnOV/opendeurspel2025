const points = [40, 100, 1, 5, 25, 10];

function selectRandomPoint() {
    console.log("before:");
    points.forEach(point => console.log(point));

    let temp = Math.floor(Math.random() * points.length);
    console.log("temp =", temp);


    console.log("Returned point is:", points[temp]);

    points.splice(temp, 1);

    console.log("after:");
    points.forEach(point => console.log(point));
}

selectRandomPoint();
