-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 09, 2019 at 03:04 AM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `webapplicationdev`
--

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

CREATE TABLE `pages` (
  `pageid` int(20) NOT NULL,
  `pagetitle` varchar(255) DEFAULT NULL,
  `pagebody` mediumtext DEFAULT NULL,
  `author` varchar(15) DEFAULT NULL,
  `Publish_Date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`pageid`, `pagetitle`, `pagebody`, `author`, `Publish_Date`) VALUES
(17, 'Home Page', 'You see, your homepage needs to wear a lot of hats. Rather than treating it like a dedicated landing page built around one particular action, it should be designed to serve different audiences, from different origins. And in order to do so effectively, it needs to be built with purpose. In other words, you\'ll need to incorporate elements that attract traffic, educate visitors, and invite conversions.', 'Madhusudhan', '2019-12-09 01:36:34'),
(18, 'About Us', 'For a remarkable about page, all you need to do is figure out your company\'s unique identity, and then share it with the world. Easy, right? Of course not. Your \"About Us\" page is one of the most important pages on your website, and it needs to be well crafted. This profile also happens to be one of the most commonly overlooked pages, which is why you should make it stand out.', 'Madhusudhan', '2019-12-09 01:38:19'),
(19, 'Contact us', 'The business name, address and phone number appears on the website only in a graphic, image or flash -- not in HTML. This information needs to be crawlable by Google and Bing. Contact info not prominent across website. The business\'s location information is only on a contact page and poorly formatted.', 'Madhusudhan', '2019-12-09 01:42:19');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pages`
--
ALTER TABLE `pages`
  ADD PRIMARY KEY (`pageid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pages`
--
ALTER TABLE `pages`
  MODIFY `pageid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
