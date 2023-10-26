console.log("**********BEGIN INIT SCRIPT**********");

// Creates the application user
db.createUser(
    {
        user: "appUser",
        pwd: "password",
        roles: [
            {
                role: "readWrite",
                db: "manglerDb",
            }
        ]
    }
);

db.createCollection("StoryLines");
db.createCollection("Stories");


/**
 * Move this into a separate script eventually
 */

// random dates in order 
var date4 = new Date(1697550100236);
var date3 = new Date(1697540100236);
var date2 = new Date(1697530100236);
var date1 = new Date(1697520100236);

db.Stories.insertOne({
    "title" : "Test Story",
    "clientType": 1,
    "authorUserIdentifier": "123abc",
    "groupIdentifier": "def456",
    "createDt": date1,
    "storyLines": [
        {
            "clientType": 1,
            "authorUserIdentifier": "123abc",
            "text": "Once upon a time there was a man named Paulie who ate three pizzas.",
            "createDt": date1
        }]
})

var storyId = db.Stories.findOne()._id;
console.log(storyId);

db.StoryLines.insertOne(
    {
        "storyId": storyId,
        "authorUserIdentifier": "jbleu",
        "text": "He at so much pepperoni that he was about to burst.",
        "createDt": date2,
        "clientType": 1
    });

db.StoryLines.insertOne(
    {
        "storyId": storyId,
        "authorUserIdentifier": "mr-sauce-man",
        "text": "Then he ordered a dessert, oh no!",
        "createDt": date3,
        "clientType": 1
    });

db.StoryLines.insertOne(
    {
        "storyId": storyId,
        "authorUserIdentifier": "hamburger-ninja512",
        "text": "Johnny made sure to eat the ice cream.",
        "createDt": date4,
        "clientType": 1
    });

console.log("**********END INIT SCRIPT**********");
