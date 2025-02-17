
const points = [40, 100, 1, 5, 25, 10];
let arrlength = points.length;


function selectRandomPoint(){
    temp = Math.floor(Math.random() * arrlength);
    console.log(temp);
    return points[temp];
}


console.log(selectRandomPoint());