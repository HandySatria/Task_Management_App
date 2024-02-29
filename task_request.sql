-- phpMyAdmin SQL Dump
-- version 5.3.0-dev+20220528.6201c7f2ba
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 29, 2024 at 09:37 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `task_request`
--

-- --------------------------------------------------------

--
-- Table structure for table `divisi`
--

CREATE TABLE `divisi` (
  `divisi_id` int(11) NOT NULL,
  `divisi_name` varchar(100) NOT NULL,
  `user_crt` varchar(100) NOT NULL,
  `user_upd` varchar(100) NOT NULL,
  `dtm_crt` datetime NOT NULL,
  `dtm_upd` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `divisi`
--

INSERT INTO `divisi` (`divisi_id`, `divisi_name`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`) VALUES
(1, 'ADMIN', 'system', 'system', '2024-02-22 10:14:06', '2024-02-22 10:14:06'),
(2, 'HRD', 'system', 'system', '2024-02-22 10:14:06', '2024-02-22 10:14:06'),
(3, 'TRAINER', 'system', 'system', '2024-02-22 10:15:08', '2024-02-22 10:15:08'),
(4, 'GENERAL AFAIR', 'system', 'system', '2024-02-22 10:15:08', '2024-02-22 10:15:08'),
(5, 'INFORMASI TEKNOLOGI', 'system', 'system', '2024-02-22 10:16:07', '2024-02-22 10:16:07'),
(6, 'PRODUKSI', 'system', 'system', '2024-02-22 10:16:07', '2024-02-22 10:16:07'),
(7, 'OUTLET', 'system', 'system', '2024-02-22 10:16:59', '2024-02-22 10:16:59'),
(8, 'OPERASIONALLL', 'admin01', 'bambang', '0000-00-00 00:00:00', '2024-02-26 09:42:35'),
(9, 'DIREKSI', 'admin01', 'admin01', '2024-02-23 00:00:00', '2024-02-23 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `hist_request`
--

CREATE TABLE `hist_request` (
  `hist_request_id` int(11) NOT NULL,
  `request_id` int(11) NOT NULL,
  `ref_status_id` int(11) NOT NULL,
  `catatan` varchar(200) NOT NULL,
  `user_crt` varchar(100) NOT NULL,
  `user_upd` varchar(100) NOT NULL,
  `dtm_crt` datetime NOT NULL,
  `dtm_upd` datetime NOT NULL,
  `estimation_start_dt` date NOT NULL,
  `estimation_end_dt` date NOT NULL,
  `realisation_start_dt` date NOT NULL,
  `realisation_end_dt` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `hist_request`
--

INSERT INTO `hist_request` (`hist_request_id`, `request_id`, `ref_status_id`, `catatan`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `estimation_start_dt`, `estimation_end_dt`, `realisation_start_dt`, `realisation_end_dt`) VALUES
(1, 15, 1, '', 'admin01', 'admin01', '2024-02-28 13:20:07', '2024-02-28 13:20:07', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(4, 11, 5, 'sabar yaaa', 'bambang', 'bambang', '2024-02-28 15:11:07', '2024-02-28 15:11:07', '2024-02-01', '2024-03-02', '0000-00-00', '0000-00-00'),
(5, 15, 5, 'akan kami kerjakan secepatnya', 'bambang', 'bambang', '2024-02-28 15:55:00', '2024-02-28 15:55:00', '2024-03-01', '2024-03-02', '0000-00-00', '0000-00-00'),
(6, 15, 6, 'kita majukan untuk tanggal mulainya', 'bambang', 'bambang', '2024-02-28 15:59:47', '2024-02-28 15:59:47', '0000-00-00', '0000-00-00', '2024-02-24', '0000-00-00'),
(7, 15, 7, 'Sudah kami selesaikan, mohon di cek kembali', 'bambang', 'bambang', '2024-02-28 16:04:11', '2024-02-28 16:04:11', '0000-00-00', '0000-00-00', '0000-00-00', '2024-02-29'),
(8, 15, 9, 'Pintu ruangan pak, bukan pintu pagar hehe', 'admin01', 'admin01', '2024-02-28 16:51:08', '2024-02-28 16:51:08', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(9, 3, 4, 'karena kita lagi padet buanget', 'admin01', 'admin01', '2024-02-29 08:55:39', '2024-02-29 08:55:39', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(10, 7, 5, 'akan kita usahakan yaaa', 'bambang', 'bambang', '2024-02-29 14:56:44', '2024-02-29 14:56:44', '2024-03-01', '2024-03-02', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `ref_prioritas`
--

CREATE TABLE `ref_prioritas` (
  `ref_prioritas_id` int(11) NOT NULL,
  `prioritas_name` varchar(100) NOT NULL,
  `description` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ref_prioritas`
--

INSERT INTO `ref_prioritas` (`ref_prioritas_id`, `prioritas_name`, `description`) VALUES
(1, 'High', 'Priotitas tinggi'),
(2, 'Medium', 'Prioritas Sedang'),
(3, 'Low', 'Prioritas Rendah');

-- --------------------------------------------------------

--
-- Table structure for table `ref_status`
--

CREATE TABLE `ref_status` (
  `ref_status_id` int(11) NOT NULL,
  `order_to` int(11) NOT NULL,
  `status_name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `parent_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ref_status`
--

INSERT INTO `ref_status` (`ref_status_id`, `order_to`, `status_name`, `description`, `parent_id`) VALUES
(1, 1, 'Terkirim', 'Request Telah Terkirim ', 0),
(2, 2, 'Dibaca', 'Request Telah dibaca oleh divisi yang bersangkutan (belum digunakan)', 0),
(3, 3, 'Accept', 'Request disetujui oleh divisi yang bersangkutan', 0),
(4, 3, 'Reject', 'Pesan tidak disetujui oleh divisi yang bersangkutan', 0),
(5, 4, 'Waiting List', 'Request menunggu antrian', 3),
(6, 5, 'On Progress', 'On Progress Pengarjaan', 3),
(7, 6, 'Done', 'Selesai Dikerjakan', 3),
(8, 7, 'Finish', 'Konfirmasi oleh pe request', 3),
(9, 8, 'Revisi', 'request sudah Done tapi belum sesuai harapan, jadi diajukan kembali untuk diperbaiki. kembali ke proses waiting list\r\n', 0);

-- --------------------------------------------------------

--
-- Table structure for table `request`
--

CREATE TABLE `request` (
  `request_id` int(11) NOT NULL,
  `from_divisi` int(11) NOT NULL,
  `to_divisi` int(11) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `description` text NOT NULL,
  `status` int(11) NOT NULL,
  `user_crt` varchar(100) NOT NULL,
  `user_upd` varchar(100) NOT NULL,
  `dtm_crt` datetime NOT NULL,
  `dtm_upd` datetime NOT NULL,
  `request_date` datetime NOT NULL,
  `prioritas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `request`
--

INSERT INTO `request` (`request_id`, `from_divisi`, `to_divisi`, `subject`, `description`, `status`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `request_date`, `prioritas`) VALUES
(1, 5, 4, 'PENGADAAN KIPAS ANGIN DIRUANGAN IT', 'SAAT INI HANYA TERDAPAT 1 KIPAS ANGIN DI RUANG IT, KARENA TERDAPAT 3 ORANG IT MAKA PERLU DI TAMBAHKAN 2 KIPAS ANGIN LAGI AGAR 1 ORANG MEMPUNYAI 1 KIPAS ANGIN ..,NHHKHGG', 8, 'system', 'admin01', '2024-02-26 07:50:01', '2024-02-27 10:57:38', '2024-02-26 07:50:01', 1),
(2, 5, 3, 'TRAINING IT', 'KITA DARI DIVISI IT AKAN MEMBUAT TRAINING BUAT KARYAWAN BARU DIVISI IT, JADI MOHON DISIAPKAN UNTUK GURUNYA HEHEHEeeee', 1, 'admin01', 'admin01', '2024-02-26 16:15:51', '2024-02-26 22:19:59', '0000-00-00 00:00:00', 2),
(3, 2, 5, 'REQUEST APLIKASI GAME', 'KAMI DARI DIVISI HRD BORING NIH, TOLONG BUATKAN APLIKASI SEJENIS MOBILE LEGEND', 4, 'arhan', 'admin01', '2024-02-26 16:19:55', '2024-02-29 08:55:39', '0000-00-00 00:00:00', 3),
(4, 2, 4, 'REQUEST MEJA DAN KURSI BUAT ANAK BARU', 'TERDAPAT KARYAWAN BARU DI DIVISI HRD, MINTA TOLONG DIBERIKAN KURSI DAN MEJA', 4, 'arhan', 'bambang', '2024-02-26 16:39:11', '2024-02-27 11:37:13', '0000-00-00 00:00:00', 2),
(5, 5, 4, 'LAMPU RUSAK', 'Lampu ruangan IT mati, minta tolong di ganti yang baru', 8, 'admin01', 'admin01', '2024-02-27 10:59:48', '2024-02-27 15:00:13', '0000-00-00 00:00:00', 3),
(6, 5, 2, 'MINTA TOLONG CARIKAN IT SUPPORT', 'Dikarenakan akan membuka 15 cabang baru kita butuh IT Support baru agar membantu pemasangan dan maintenence', 1, 'admin01', 'admin01', '2024-02-27 15:02:34', '2024-02-27 17:28:56', '0000-00-00 00:00:00', 1),
(7, 5, 4, 'KERAN KAMAR MANDI BOCOR', 'kerana kamar mandi di ruangan IT mampet karena tersumbal bola plastik, kita minta tolong untuk diperbaiki keranya', 5, 'admin01', 'bambang', '2024-02-27 15:04:40', '2024-02-29 14:56:44', '0000-00-00 00:00:00', 2),
(8, 2, 4, 'KAKI KURSI PATAH', 'Di ruangan HRD kaki kuri yang sebelumnya 4 tinggal 3, akibatnya kursi tidak bisa digunakan. tolong pasangkan kaki kursi agar kembali menjadi 4 kaki', 1, 'arhan', 'arhan', '2024-02-27 15:15:06', '2024-02-27 15:15:06', '0000-00-00 00:00:00', 2),
(9, 5, 4, 'REQUEST GALON BARU', 'di rangan IT galonya bocor, minta tolong diberi galon baru yang buagus hehe', 1, 'admin01', 'admin01', '2024-02-27 16:32:25', '2024-02-27 16:32:25', '0000-00-00 00:00:00', 2),
(10, 5, 4, 'REQUEST PANCI BARU', 'di ruangan IT Pancinya rusak, minta tolong dibelikan panci baru agar bisa buat bikin mie instan', 1, 'admin01', 'bambang', '2024-02-27 16:34:14', '2024-02-28 14:30:23', '0000-00-00 00:00:00', 2),
(11, 5, 4, 'REQUEST GELAS ', 'gelas di ruangan IT bocor pak, ketik minum jadinya tumpah deh', 5, 'admin01', 'bambang', '2024-02-27 16:36:40', '2024-02-28 15:11:07', '0000-00-00 00:00:00', 2),
(12, 5, 2, 'KEBUTUHAN TRAINING OUTLET', 'terdapat beberapa outlet baru yang membutuhkan training agar lebih leluasa saat melayani pelanggan dan penataan display roti', 1, 'admin01', 'admin01', '2024-02-27 16:49:41', '2024-02-27 17:26:17', '0000-00-00 00:00:00', 1),
(13, 5, 4, 'PEMBELIAN KULKAS', 'Kami dari divisi IT kalau siang kehausan dan pingin minum air dingin agar badan tetap sehat dan bugar. tolong dibelikan kulkas dong di ruangan IT.', 8, 'admin01', 'admin01', '2024-02-27 17:51:59', '2024-02-27 18:30:11', '0000-00-00 00:00:00', 2),
(15, 5, 4, 'REQUEST PERBAIKAN PINTU', 'Pintu di ruangan IT patah setengaj, jadi minta tolong untuk dipanggilkan tukang untuk diperbaiki pintunya', 9, 'admin01', 'admin01', '2024-02-28 13:20:07', '2024-02-28 16:51:08', '0000-00-00 00:00:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `fullname` varchar(150) NOT NULL,
  `divisi_id` int(11) NOT NULL,
  `user_crt` varchar(100) NOT NULL,
  `user_upd` varchar(100) NOT NULL,
  `dtm_crt` datetime NOT NULL,
  `dtm_upd` datetime NOT NULL,
  `chat_id_telegram` int(11) NOT NULL,
  `is_admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `username`, `password`, `fullname`, `divisi_id`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `chat_id_telegram`, `is_admin`) VALUES
(1, 'admin01', 'Wzmb8+GoyAQ=', 'HANDY SATRIA', 5, 'system', 'admin01', '2024-02-22 10:06:12', '2024-02-26 10:24:21', 1486234824, 1),
(2, 'bagas', 'LT3UArJ8LQQ=', 'BAGAS KAHFAA', 6, 'admin01', 'admin01', '2024-02-26 09:24:34', '2024-02-26 10:28:51', 1486234824, 0),
(3, 'maulana', 'W34DDTl2hBI=', 'EGY MAULANA', 1, 'admin01', 'admin01', '2024-02-26 09:33:42', '2024-02-26 09:33:42', 1486234824, 0),
(4, 'arhan', 'UrlBG1zKFRE=', 'ARHAN PRATAMA', 2, 'admin01', 'admin01', '2024-02-26 09:34:14', '2024-02-26 09:34:14', 1560150396, 0),
(5, 'bambang', 'GJCH3OtiqDs=', 'BAMBANG PAMUNGKAS', 4, 'admin01', 'admin01', '2024-02-26 09:34:50', '2024-02-26 10:29:54', 1486234824, 0),
(7, 'luhut', 'sY6gPsscmA8=', 'LUHUT BINSAR', 9, 'admin01', 'admin01', '2024-02-26 10:35:24', '2024-02-26 10:35:52', 1486234824, 1),
(9, 'maman', 'sF1jXMY4oAM=', 'MAMAN ABDURAHMAN', 7, 'admin01', 'admin01', '2024-02-26 10:36:37', '2024-02-26 10:36:37', 1486234824, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `divisi`
--
ALTER TABLE `divisi`
  ADD PRIMARY KEY (`divisi_id`);

--
-- Indexes for table `hist_request`
--
ALTER TABLE `hist_request`
  ADD PRIMARY KEY (`hist_request_id`),
  ADD KEY `hist_request_request_id` (`request_id`);

--
-- Indexes for table `ref_prioritas`
--
ALTER TABLE `ref_prioritas`
  ADD PRIMARY KEY (`ref_prioritas_id`);

--
-- Indexes for table `ref_status`
--
ALTER TABLE `ref_status`
  ADD PRIMARY KEY (`ref_status_id`);

--
-- Indexes for table `request`
--
ALTER TABLE `request`
  ADD PRIMARY KEY (`request_id`),
  ADD KEY `request_from_divisi_id` (`from_divisi`),
  ADD KEY `request_to_divisi_id` (`to_divisi`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `user_divisi_id` (`divisi_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `divisi`
--
ALTER TABLE `divisi`
  MODIFY `divisi_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `hist_request`
--
ALTER TABLE `hist_request`
  MODIFY `hist_request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ref_prioritas`
--
ALTER TABLE `ref_prioritas`
  MODIFY `ref_prioritas_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `ref_status`
--
ALTER TABLE `ref_status`
  MODIFY `ref_status_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `request`
--
ALTER TABLE `request`
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `hist_request`
--
ALTER TABLE `hist_request`
  ADD CONSTRAINT `hist_request_request_id` FOREIGN KEY (`request_id`) REFERENCES `request` (`request_id`);

--
-- Constraints for table `request`
--
ALTER TABLE `request`
  ADD CONSTRAINT `request_from_divisi_id` FOREIGN KEY (`from_divisi`) REFERENCES `divisi` (`divisi_id`),
  ADD CONSTRAINT `request_to_divisi_id` FOREIGN KEY (`to_divisi`) REFERENCES `divisi` (`divisi_id`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_divisi_id` FOREIGN KEY (`divisi_id`) REFERENCES `divisi` (`divisi_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;



