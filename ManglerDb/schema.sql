-- Use this file to define the initial structure of the database.  
-- This is run by Docker at startup to define the database.

-- ------------------------------------------------------------------------------------------
-- DROP EXISTING DATABASE AND RECREATE
-- ------------------------------------------------------------------------------------------
-- select 'hello world'
drop database if exists manglerDb;
create database manglerDb;


-- ------------------------------------------------------------------------------------------
-- GENERATE TABLES
-- ------------------------------------------------------------------------------------------

use manglerDb;

--
-- A story is a grouping of storylines with an author, group, and title
--
create table Story(
                      Id int not null auto_increment,
                      Title nvarchar(120),
                      AuthorId int,
                      GuildId int,
                      CompleteDt datetime,
                      CreateDt datetime,
                      IsViewableByPublic bit,
                      IsWritableByPublic bit,
                      PRIMARY KEY (Id)
);

-- since we will commonly find stories for a given group
create index idx_groupid on Story(GuildId);
-- since we will commonly find stories a user's own stories
create index idx_authoruserid on Story(AuthorId);

--
-- A storyline is a line of a story.  Lines are always written by a particular user.
--
create table StoryLine(
                          Id int not null auto_increment,
                          StoryId int not null,
                          AuthorId int not null,
                          Text nvarchar(200),
                          CreateDt datetime,
                          CompleteDt datetime,
                          PRIMARY KEY (Id)
);

-- most common use case is finding the latest few lines of a story
create index idx_storyid_createdt on StoryLine(StoryId, CreateDt desc);

--
-- Represents a grouping of users that share stories with each other. 
-- The best example would be a client type of 'discord' and an identifier being the guildId
-- Contrary to naming, this doesn't have to be a discord server.
--
create table Guild(
                      Id int not null auto_increment,
                      GuildIdentifier nvarchar(200) not null,
                      ClientType tinyint not null,
                      Primary Key (Id)
);

--
-- Join table between an author and it's guild, since one user may be part of 
-- many guilds.
--
create table AuthorGuild(
                            AuthorId int not null,
                            GuildId int not null,
                            PRIMARY KEY (AuthorId, GuildId)
);

--
-- An author is logically a 'user', except for authentication stuff
--
create table Author(
                       Id int not null auto_increment,
                       Name nvarchar(100),
                       UserIdentifier nvarchar(200) not null,
                       ClientType int not null,
                       PRIMARY KEY (Id)
);

create index idx_clienttype_useridentifier on Author(ClientType, UserIdentifier);
