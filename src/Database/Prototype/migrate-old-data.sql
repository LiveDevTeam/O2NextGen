-- Author: DENIS PROKHORCHIK
-- Date: 06/01/2022

-- Create temp table of Certificates
CREATE TABLE #TempCertificates
(
    Id UNIQUEIDENTIFIER,
    added_date bigint
);

-- Create temp table of Users
CREATE TABLE #TempUsers
(
    Id UNIQUEIDENTIFIER
)

-- Select a data of old Certificate table
USE [O2Bionics.O2Platform.CertificateDB]
SELECT * FROM O2CCertificate

-- Select a data of old Users table
USE [O2Bionics.O2Platform.IdentityDb]
SELECT * FROM AspNetUsers

-- Merge tables

-- Export file to JSON format






-- USE [O2Bionics.O2Platform.CertificateDB]
-- SELECT * FROM O2CCertificate
-- FOR JSON PATH

-- USE [O2Bionics.O2Platform.IdentityDb]
-- SELECT * FROM AspNetUsers

-- select * from Photos





