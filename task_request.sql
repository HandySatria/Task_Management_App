-- phpMyAdmin SQL Dump
-- version 5.3.0-dev+20220528.6201c7f2ba
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 27, 2024 at 05:42 AM
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
(1, 'Admin', 'system', 'system', '2024-02-22 10:14:06', '2024-02-22 10:14:06'),
(2, 'HRD', 'system', 'system', '2024-02-22 10:14:06', '2024-02-22 10:14:06'),
(3, 'Trainer', 'system', 'system', '2024-02-22 10:15:08', '2024-02-22 10:15:08'),
(4, 'General Affair', 'system', 'system', '2024-02-22 10:15:08', '2024-02-22 10:15:08'),
(5, 'Informasi Teknologi', 'system', 'system', '2024-02-22 10:16:07', '2024-02-22 10:16:07'),
(6, 'Produksi', 'system', 'system', '2024-02-22 10:16:07', '2024-02-22 10:16:07'),
(7, 'Outlet', 'system', 'system', '2024-02-22 10:16:59', '2024-02-22 10:16:59'),
(8, 'OPERASIONALLL', 'admin01', 'bambang', '0000-00-00 00:00:00', '2024-02-26 09:42:35'),
(9, 'DIREKSI', 'admin01', 'admin01', '2024-02-23 00:00:00', '2024-02-23 00:00:00');

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
(2, 2, 'Dibaca', 'Request Telah dibaca oleh divisi yang bersangkutan', 0),
(3, 3, 'Disetujui', 'Request disetujui oleh divisi yang bersangkutan', 0),
(4, 3, 'Tidak Disetujui', 'Pesan tidak disetujui oleh divisi yang bersangkutan', 0),
(5, 4, 'Waiting List', 'Request menunggu antrian', 3),
(6, 5, 'On Progress', 'On Progress Pengarjaan', 3),
(7, 6, 'Done', 'Selesai Dikerjakan', 3),
(8, 7, 'Finish', 'Konfirmasi oleh pe request', 3);

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
  `prioritas` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `request`
--

INSERT INTO `request` (`request_id`, `from_divisi`, `to_divisi`, `subject`, `description`, `status`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `request_date`, `prioritas`) VALUES
(1, 5, 4, 'PENGADAAN KIPAS ANGIN DIRUANGAN IT', 'SAAT INI HANYA TERDAPAT 1 KIPAS ANGIN DI RUANG IT, KARENA TERDAPAT 3 ORANG IT MAKA PERLU DI TAMBAHKAN 2 KIPAS ANGIN LAGI AGAR 1 ORANG MEMPUNYAI 1 KIPAS ANGIN ..,NHHKHGG', 8, 'system', 'admin01', '2024-02-26 07:50:01', '2024-02-27 10:57:38', '2024-02-26 07:50:01', ''),
(2, 5, 3, 'TRAINING IT', 'KITA DARI DIVISI IT AKAN MEMBUAT TRAINING BUAT KARYAWAN BARU DIVISI IT, JADI MOHON DISIAPKAN UNTUK GURUNYA HEHEHEeeee', 1, 'admin01', 'admin01', '2024-02-26 16:15:51', '2024-02-26 22:19:59', '0000-00-00 00:00:00', ''),
(3, 2, 5, 'REQUEST APLIKASI GAME', 'KAMI DARI DIVISI HRD BORING NIH, TOLONG BUATKAN APLIKASI SEJENIS MOBILE LEGEND', 1, 'arhan', 'arhan', '2024-02-26 16:19:55', '2024-02-26 16:19:55', '0000-00-00 00:00:00', ''),
(4, 2, 4, 'REQUEST MEJA DAN KURSI BUAT ANAK BARU', 'TERDAPAT KARYAWAN BARU DI DIVISI HRD, MINTA TOLONG DIBERIKAN KURSI DAN MEJA', 4, 'arhan', 'bambang', '2024-02-26 16:39:11', '2024-02-27 11:37:13', '0000-00-00 00:00:00', ''),
(5, 5, 4, 'LAMPU RUSAK', 'Lampu ruangan IT mati, minta tolong di ganti yang baru', 8, 'admin01', 'admin01', '2024-02-27 10:59:48', '2024-02-27 11:04:09', '0000-00-00 00:00:00', '');

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
  `dtm_upd` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `username`, `password`, `fullname`, `divisi_id`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`) VALUES
(1, 'admin01', 'Wzmb8+GoyAQ=', 'HANDY SATRIA', 5, 'system', 'admin01', '2024-02-22 10:06:12', '2024-02-26 10:24:21'),
(2, 'bagas', 'LT3UArJ8LQQ=', 'BAGAS KAHFAA', 6, 'admin01', 'admin01', '2024-02-26 09:24:34', '2024-02-26 10:28:51'),
(3, 'maulana', 'W34DDTl2hBI=', 'EGY MAULANA', 1, 'admin01', 'admin01', '2024-02-26 09:33:42', '2024-02-26 09:33:42'),
(4, 'arhan', 'UrlBG1zKFRE=', 'ARHAN PRATAMA', 2, 'admin01', 'admin01', '2024-02-26 09:34:14', '2024-02-26 09:34:14'),
(5, 'bambang', 'GJCH3OtiqDs=', 'BAMBANG PAMUNGKAS', 4, 'admin01', 'admin01', '2024-02-26 09:34:50', '2024-02-26 10:29:54'),
(7, 'luhut', 'sY6gPsscmA8=', 'LUHUT BINSAR', 9, 'admin01', 'admin01', '2024-02-26 10:35:24', '2024-02-26 10:35:52'),
(9, 'maman', 'sF1jXMY4oAM=', 'MAMAN ABDURAHMAN', 7, 'admin01', 'admin01', '2024-02-26 10:36:37', '2024-02-26 10:36:37');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `divisi`
--
ALTER TABLE `divisi`
  ADD PRIMARY KEY (`divisi_id`);

--
-- Indexes for table `ref_status`
--
ALTER TABLE `ref_status`
  ADD PRIMARY KEY (`ref_status_id`);

--
-- Indexes for table `request`
--
ALTER TABLE `request`
  ADD PRIMARY KEY (`request_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `divisi`
--
ALTER TABLE `divisi`
  MODIFY `divisi_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `ref_status`
--
ALTER TABLE `ref_status`
  MODIFY `ref_status_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `request`
--
ALTER TABLE `request`
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;



