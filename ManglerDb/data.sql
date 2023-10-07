-- Use this file to populate test data
-- This is run by Docker at startup after schema.sql

-- ------------------------------------------------------------------------------------------
-- GENERATE TEST DATA
-- ------------------------------------------------------------------------------------------
use manglerDb;

-- create a guild
insert into Guild (GuildIdentifier, ClientType) values('abc123', 1);
set @guildId := (select Guild.Id from Guild limit 1);

-- Create some authors
insert into Author (`Name`, UserIdentifier, ClientType) values('john Smiff', 'abc123', 1);
insert into Author (`Name`, UserIdentifier, ClientType) values('lxl_BigBingus_lxl', 'def456', 1);
insert into Author (`Name`, UserIdentifier, ClientType) values('Lil Pringles', 'ghi789', 1);
insert into Author (`Name`, UserIdentifier, ClientType) values('beef.', 'jkl012', 1);

set @authorId1 := (select Id from Author where UserIdentifier = 'abc123' limit 1);
set @authorId2 := (select Id from Author where UserIdentifier = 'def456' limit 1);
set @authorId3 := (select Id from Author where UserIdentifier = 'ghi789' limit 1);
set @authorId4 := (select Id from Author where UserIdentifier = 'jkl012' limit 1);

-- Add them to the group
insert into AuthorGuild values (@authorId1, @GuildId);
insert into AuthorGuild values (@authorId2, @GuildId);
insert into AuthorGuild values (@authorId3, @GuildId);
insert into AuthorGuild values (@authorId4, @GuildId);

set @storyWrittenDate := date_sub(now(), interval 1 day);

-- create a story within that guild
insert into Story (Title, AuthorId, GuildId, CompleteDt, CreateDt, IsViewableByPublic, IsWritableByPublic)
values ('The Last Melon', @authorId1, @guildId, @storyWrittenDate, now(), 0, 0);

set @storyId := (select Id from Story limit 1);

-- write some story lines
insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId1,
       'This is the story of the last melon.',
       date_add(@storyWrittenDate, interval 1 minute),
       date_add(@storyWrittenDate, interval 1 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId2,
       'His friends made fun of him for being the only melon in the friend group.',
       date_add(@storyWrittenDate, interval 2 minute),
       date_add(@storyWrittenDate, interval 2 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId1,
       'His other friends were a carrot, a celery, and a piece of lettuce.',
       date_add(@storyWrittenDate, interval 3 minute),
       date_add(@storyWrittenDate, interval 3 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId3,
       'The piece of lettuce was named Bruno.',
       date_add(@storyWrittenDate, interval 4 minute),
       date_add(@storyWrittenDate, interval 4 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId4,
       'Bruno always wanted to be part of a salad someday.',
       date_add(@storyWrittenDate, interval 5 minute),
       date_add(@storyWrittenDate, interval 5 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId1,
       'He did his best to become a salad, but he failed.',
       date_add(@storyWrittenDate, interval 6 minute),
       date_add(@storyWrittenDate, interval 6 minute));

insert into StoryLine (StoryId, AuthorId, Text, CreateDt, CompleteDt)
values(@storyId, @authorId4,
       'In the end, nothing ever changed, and people still made fun of the Last melon.',
       date_add(@storyWrittenDate, interval 7 minute),
       date_add(@storyWrittenDate, interval 7 minute))