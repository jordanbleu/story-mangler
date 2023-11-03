-- ------------------------------------------------------------------------------------------
-- GENERATE TEST DATA
-- ------------------------------------------------------------------------------------------
set @yesterday := date_sub(now(), interval 1 day);
set @2daysAgo := date_sub(now(), interval 2 day);
set @3daysAgo := date_sub(now(), interval 3 day);
set @4daysAgo := date_sub(now(), interval 3 day);
set @5daysAgo := date_sub(now(), interval 3 day);

insert into Story (
                   Title, 
                   AuthorUserIdentifier, 
                   AuthorClientType,
                   GuildIdentifier, 
                   CompleteDt,
                   CreateDt, 
                   IsViewableByPublic, 
                   IsWritableByPublic)
values (
        'The Biggest Pizza',
        'lxl_G4MER_lxl',
        1,
        'dkjsldfj3kj23k23',
        @yesterday,
        @5daysAgo,
        1,
        0     
       );

set @storyId := (select Id from Story limit 1);

insert into StoryLine (
                       StoryId,
                       AuthorUserIdentifier,
                       AuthorClientType,
                       Text, 
                       CreateDt,
                       CompleteDt
) values (
          @storyId,
          'lxl_G4MER_lxl',
          1,
          'This is the story of the world''s biggest piza.',
          @4daysAgo,
          @4daysAgo          
         );

insert into StoryLine (
    StoryId,
    AuthorUserIdentifier,
    AuthorClientType,
    Text,
    CreateDt,
    CompleteDt
) values (
             @storyId,
             'mr-potatoman',
             1,
             'Tony loved to eat that pizza so much.  It was amazing!',
             @3daysAgo,
             @3daysAgo
         );

insert into StoryLine (
    StoryId,
    AuthorUserIdentifier,
    AuthorClientType,
    Text,
    CreateDt,
    CompleteDt
) values (
             @storyId,
             'RichardMontgomeryJones',
             1,
             'But he didnt like it from Fazolis.',
             @2daysAgo,
             @2daysAgo
         );

insert into StoryLine (
    StoryId,
    AuthorUserIdentifier,
    AuthorClientType,
    Text,
    CreateDt,
    CompleteDt
) values (
             @storyId,
             'juan.lopez',
             1,
             'So instead he got Olive Garden, and went home for the day',
             @yesterday,
             @yesterday
         );