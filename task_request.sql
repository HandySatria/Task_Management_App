-- phpMyAdmin SQL Dump
-- version 5.3.0-dev+20220528.6201c7f2ba
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 21, 2024 at 02:45 AM
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
(5, 'INFORMASI TEKNOLOGI', 'system', 'admin01', '2024-02-22 10:16:07', '2024-03-01 15:53:54'),
(6, 'PRODUKSI', 'system', 'system', '2024-02-22 10:16:07', '2024-02-22 10:16:07'),
(7, 'OUTLET', 'system', 'system', '2024-02-22 10:16:59', '2024-02-22 10:16:59'),
(8, 'OPERASIONALLL', 'admin01', 'bambang', '0000-00-00 00:00:00', '2024-02-26 09:42:35'),
(9, 'DIREKSI', 'admin01', 'admin01', '2024-02-23 00:00:00', '2024-02-23 00:00:00'),
(14, 'HURA HURAA', 'admin01', 'admin01', '2024-03-20 11:55:39', '2024-03-20 11:55:54');

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
(10, 7, 5, 'akan kita usahakan yaaa', 'bambang', 'bambang', '2024-02-29 14:56:44', '2024-02-29 14:56:44', '2024-03-01', '2024-03-02', '0000-00-00', '0000-00-00'),
(11, 16, 1, '', 'satria', 'satria', '2024-02-29 15:48:41', '2024-02-29 15:48:41', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(12, 16, 5, 'akan kamu kerjakan segera pak', 'okky', 'okky', '2024-02-29 15:53:25', '2024-02-29 15:53:25', '2024-03-01', '2024-03-01', '0000-00-00', '0000-00-00'),
(13, 16, 6, 'kita ajukan untuk perbaikanya hari ini karna tukangnya sudah ready', 'okky', 'okky', '2024-02-29 15:57:06', '2024-02-29 15:57:06', '0000-00-00', '0000-00-00', '2024-02-29', '0000-00-00'),
(14, 16, 7, 'sudah kami kerjakan mohon di cek kembali', 'okky', 'okky', '2024-02-29 15:59:11', '2024-02-29 15:59:11', '0000-00-00', '0000-00-00', '0000-00-00', '2024-02-29'),
(15, 16, 9, 'kayunya kurang 1 pak, masih bocor', 'satria', 'satria', '2024-02-29 16:06:31', '2024-02-29 16:06:31', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(16, 16, 9, 'kayunya kurang 1 pak, masih bocor', 'satria', 'satria', '2024-02-29 16:06:36', '2024-02-29 16:06:36', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(17, 16, 4, 'kayunya lipatan itu pak, itu bisa dilipat lagi ager penuh', 'okky', 'okky', '2024-02-29 16:09:02', '2024-02-29 16:09:02', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(18, 17, 1, '', 'admin01', 'admin01', '2024-03-01 09:51:36', '2024-03-01 09:51:36', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(19, 18, 1, '', 'admin01', 'admin01', '2024-03-01 09:54:16', '2024-03-01 09:54:16', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(20, 19, 1, '', 'admin01', 'admin01', '2024-03-01 10:05:58', '2024-03-01 10:05:58', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(21, 20, 1, '', 'admin01', 'admin01', '2024-03-01 10:09:24', '2024-03-01 10:09:24', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(22, 21, 1, '', 'admin01', 'admin01', '2024-03-01 15:06:26', '2024-03-01 15:06:26', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(23, 22, 1, '', 'admin01', 'admin01', '2024-03-01 15:24:24', '2024-03-01 15:24:24', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(24, 23, 1, '', 'satria', 'satria', '2024-03-01 15:30:03', '2024-03-01 15:30:03', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(25, 24, 1, '', 'admin01', 'admin01', '2024-03-02 17:26:16', '2024-03-02 17:26:16', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(26, 24, 5, 'akan kami buatkan pada tanggal yang tertera', 'bagas', 'bagas', '2024-03-03 18:50:32', '2024-03-03 18:50:32', '2024-03-06', '2024-03-07', '0000-00-00', '0000-00-00'),
(27, 24, 5, 'akan kami buatkan pada tanggal yang tertera', 'bagas', 'bagas', '2024-03-03 18:50:32', '2024-03-03 18:50:32', '2024-03-06', '2024-03-07', '0000-00-00', '0000-00-00'),
(28, 25, 1, '', 'admin01', 'admin01', '2024-03-08 16:11:19', '2024-03-08 16:11:19', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(29, 11, 6, 'proses\r\n', 'bambang', 'bambang', '2024-03-13 09:22:27', '2024-03-13 09:22:27', '0000-00-00', '0000-00-00', '2024-03-01', '0000-00-00'),
(30, 11, 7, 'sudah selesai\r\n', 'bambang', 'bambang', '2024-03-13 09:26:19', '2024-03-13 09:26:19', '0000-00-00', '0000-00-00', '0000-00-00', '2024-03-31'),
(31, 26, 1, '', 'admin01', 'admin01', '2024-03-16 09:12:52', '2024-03-16 09:12:52', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00'),
(32, 15, 5, 'akan kita kerjakan', 'bambang', 'bambang', '2024-03-16 12:00:30', '2024-03-16 12:00:30', '2024-03-18', '2024-03-19', '0000-00-00', '0000-00-00'),
(33, 15, 6, 'kita kerjakan hari ini', 'bambang', 'bambang', '2024-03-16 12:01:10', '2024-03-16 12:01:10', '0000-00-00', '0000-00-00', '2024-03-16', '0000-00-00'),
(34, 15, 7, 'sudah selesai hari ini juga', 'bambang', 'bambang', '2024-03-16 12:01:36', '2024-03-16 12:01:36', '0000-00-00', '0000-00-00', '0000-00-00', '2024-03-16'),
(35, 8, 5, 'akan kami kerjakan besok yaa', 'bambang', 'bambang', '2024-03-18 11:19:34', '2024-03-18 11:19:34', '2024-03-19', '2024-03-19', '0000-00-00', '0000-00-00'),
(36, 17, 5, 'kita akan perbaiki besok gaes', 'bambang', 'bambang', '2024-03-18 11:20:37', '2024-03-18 11:20:37', '2024-03-19', '2024-03-19', '0000-00-00', '0000-00-00'),
(37, 17, 6, 'kita kerjakan hari ini saja ya', 'bambang', 'bambang', '2024-03-18 11:21:57', '2024-03-18 11:21:57', '0000-00-00', '0000-00-00', '2024-03-18', '0000-00-00'),
(38, 17, 7, 'sudah selesai yaa', 'bambang', 'bambang', '2024-03-18 11:22:34', '2024-03-18 11:22:34', '0000-00-00', '0000-00-00', '0000-00-00', '2024-03-18'),
(39, 17, 9, 'masih patah bawahnya pak', 'admin01', 'admin01', '2024-03-18 11:25:12', '2024-03-18 11:25:12', '0000-00-00', '0000-00-00', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `mcabang`
--

CREATE TABLE `mcabang` (
  `id` int(11) NOT NULL,
  `nama` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mcabang`
--

INSERT INTO `mcabang` (`id`, `nama`) VALUES
(1, 'Nias'),
(2, 'Kutai'),
(3, 'Rungkut'),
(4, 'Wiyung'),
(5, 'Darmahusada'),
(6, 'Barata'),
(8, 'Perak'),
(15, 'Darmo Permai'),
(16, 'Gayung Sari'),
(17, 'Diponegoro - Sidoarjo'),
(18, 'Menganti - Gresik'),
(19, 'Manukan'),
(21, 'ST.Gubeng'),
(22, 'Tropodo - Sidoarjo'),
(23, 'ST. Pasar Turi'),
(24, 'Iskandar Muda'),
(25, 'Deltasari - Sidoarjo'),
(26, 'Sepanjang - Sidoarjo'),
(27, 'Krian - Sidoarjo'),
(28, 'Kapas Krampung');

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
  `prioritas` int(11) NOT NULL,
  `request_no` varchar(50) NOT NULL,
  `urutan_ke` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `is_cancel` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `request`
--

INSERT INTO `request` (`request_id`, `from_divisi`, `to_divisi`, `subject`, `description`, `status`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `request_date`, `prioritas`, `request_no`, `urutan_ke`, `user_id`, `is_cancel`) VALUES
(1, 5, 4, 'PENGADAAN KIPAS ANGIN DIRUANGAN IT', 'SAAT INI HANYA TERDAPAT 1 KIPAS ANGIN DI RUANG IT, KARENA TERDAPAT 3 ORANG IT MAKA PERLU DI TAMBAHKAN 2 KIPAS ANGIN LAGI AGAR 1 ORANG MEMPUNYAI 1 KIPAS ANGIN ..,NHHKHGG', 8, 'system', 'admin01', '2024-02-26 07:50:01', '2024-02-27 10:57:38', '2024-02-26 07:50:01', 1, '001/02/2024', 1, 1, 1),
(2, 5, 3, 'TRAINING IT', 'KITA DARI DIVISI IT AKAN MEMBUAT TRAINING BUAT KARYAWAN BARU DIVISI IT, JADI MOHON DISIAPKAN UNTUK GURUNYA HEHEHEeeee', 1, 'admin01', 'admin01', '2024-02-26 16:15:51', '2024-03-04 08:38:02', '0000-00-00 00:00:00', 2, '002/02/2024', 2, 1, 0),
(3, 2, 5, 'REQUEST APLIKASI GAME', 'KAMI DARI DIVISI HRD BORING NIH, TOLONG BUATKAN APLIKASI SEJENIS MOBILE LEGEND', 4, 'arhan', 'admin01', '2024-02-26 16:19:55', '2024-02-29 08:55:39', '0000-00-00 00:00:00', 3, '003/02/2024', 3, 4, 0),
(4, 2, 4, 'REQUEST MEJA DAN KURSI BUAT ANAK BARU', 'TERDAPAT KARYAWAN BARU DI DIVISI HRD, MINTA TOLONG DIBERIKAN KURSI DAN MEJA', 4, 'arhan', 'bambang', '2024-02-26 16:39:11', '2024-02-27 11:37:13', '0000-00-00 00:00:00', 2, '004/02/2024', 4, 4, 0),
(5, 5, 4, 'LAMPU RUSAK', 'Lampu ruangan IT mati, minta tolong di ganti yang baru', 8, 'admin01', 'admin01', '2024-02-27 10:59:48', '2024-02-27 15:00:13', '0000-00-00 00:00:00', 3, '005/02/2024', 5, 1, 0),
(6, 5, 2, 'MINTA TOLONG CARIKAN IT SUPPORT', 'Dikarenakan akan membuka 15 cabang baru kita butuh IT Support baru agar membantu pemasangan dan maintenence', 1, 'admin01', 'admin01', '2024-02-27 15:02:34', '2024-02-27 17:28:56', '0000-00-00 00:00:00', 1, '006/02/2024', 6, 1, 0),
(7, 5, 4, 'KERAN KAMAR MANDI BOCOR', 'kerana kamar mandi di ruangan IT mampet karena tersumbal bola plastik, kita minta tolong untuk diperbaiki keranya', 5, 'admin01', 'bambang', '2024-02-27 15:04:40', '2024-02-29 14:56:44', '0000-00-00 00:00:00', 2, '007/02/2024', 7, 1, 0),
(8, 2, 4, 'KAKI KURSI PATAH SEBELAH', 'Di ruangan HRD kaki kuri yang sebelumnya 4 tinggal 3, akibatnya kursi tidak bisa digunakan. tolong pasangkan kaki kursi agar kembali menjadi 4 kaki', 5, 'arhan', 'bambang', '2024-02-27 15:15:06', '2024-03-18 11:19:34', '0000-00-00 00:00:00', 2, '008/02/2024', 8, 4, 0),
(9, 5, 4, 'REQUEST GALON BARU', 'di rangan IT galonya bocor, minta tolong diberi galon baru yang buagus hehe', 1, 'admin01', 'admin01', '2024-02-27 16:32:25', '2024-02-27 16:32:25', '0000-00-00 00:00:00', 2, '009/02/2024', 9, 1, 0),
(10, 5, 4, 'REQUEST PANCI BARU', 'di ruangan IT Pancinya rusak, minta tolong dibelikan panci baru agar bisa buat bikin mie instan', 5, 'admin01', 'bambang', '2024-02-27 16:34:14', '2024-03-01 15:55:57', '0000-00-00 00:00:00', 2, '010/02/2024', 10, 1, 0),
(11, 5, 4, 'REQUEST GELAS ', 'gelas di ruangan IT bocor pak, ketik minum jadinya tumpah deh', 8, 'admin01', 'admin01', '2024-02-27 16:36:40', '2024-03-18 11:14:03', '0000-00-00 00:00:00', 2, '011/02/2024', 11, 1, 0),
(12, 5, 2, 'KEBUTUHAN TRAINING OUTLET CABANG BARU', 'terdapat beberapa outlet baru yang membutuhkan training agar lebih leluasa saat melayani pelanggan dan penataan display roti', 1, 'admin01', 'admin01', '2024-02-27 16:49:41', '2024-03-04 09:18:32', '0000-00-00 00:00:00', 1, '012/02/2024', 12, 1, 0),
(13, 5, 4, 'PEMBELIAN KULKAS', 'Kami dari divisi IT kalau siang kehausan dan pingin minum air dingin agar badan tetap sehat dan bugar. tolong dibelikan kulkas dong di ruangan IT.', 8, 'admin01', 'admin01', '2024-02-27 17:51:59', '2024-02-27 18:30:11', '0000-00-00 00:00:00', 2, '013/02/2024', 13, 1, 0),
(15, 5, 4, 'REQUEST PERBAIKAN PINTU', 'Pintu di ruangan IT patah setengaj, jadi minta tolong untuk dipanggilkan tukang untuk diperbaiki pintunya', 8, 'admin01', 'admin01', '2024-02-28 13:20:07', '2024-03-16 12:02:17', '0000-00-00 00:00:00', 1, '014/02/2024', 14, 1, 0),
(16, 5, 4, 'CENDELA RUSAK SETENGAH', 'cendela di ruangan IT patah pak, minta tolong untuk dikirim tukang untuk memperbaiki besok ya', 4, 'satria', 'okky', '2024-02-29 15:48:41', '2024-02-29 16:09:01', '0000-00-00 00:00:00', 1, '015/02/2024', 15, 10, 0),
(17, 5, 4, 'PERBAIKAN GAGANG PINTU', 'GAGANG PINTU DI RUANG IT DI GIGIT RAYAP PAK, MINTA TOLONG UNTUK DIGANTI YANG BARU', 9, 'admin01', 'admin01', '2024-03-01 09:51:36', '2024-03-18 11:25:12', '0000-00-00 00:00:00', 1, 'REQ001/03/2024', 0, 1, 0),
(18, 5, 6, 'PESANAN BANYAK', 'TERDAPAT PESANAN YANG LUMAYAN BANYAK, BUAT PT INDONESIA MAJU, TOLONG DISELESIKAN BESOK', 1, 'admin01', 'admin01', '2024-03-01 09:54:16', '2024-03-04 10:48:22', '0000-00-00 00:00:00', 1, 'REQ002/03/2024', 0, 1, 0),
(19, 5, 3, 'PELATIHAN KODING', 'minta tolong dibuatkan pelatihan koding untuk programmer IT yang baru....', 1, 'admin01', 'admin01', '2024-03-01 10:05:58', '2024-03-16 09:02:09', '0000-00-00 00:00:00', 2, 'REQ003/03/2024', 0, 1, 0),
(20, 5, 6, 'MILKBUN HABIS', 'karena Milkbun laris manis di outlet baratajaya, minta tolong untuk dibuatkan lebih banyak lagi agar stok terpenuhi', 1, 'admin01', 'admin01', '2024-03-01 10:09:24', '2024-03-01 10:09:24', '0000-00-00 00:00:00', 2, 'REQ004/03/2024', 0, 1, 0),
(21, 5, 6, 'BOMBOLONI HABIS', 'tolong dibuatkan extra roti bomboloni agar stok mencukupi', 1, 'admin01', 'admin01', '2024-03-01 15:06:26', '2024-03-01 15:06:26', '0000-00-00 00:00:00', 2, 'REQ005/03/2024', 0, 1, 0),
(22, 5, 6, 'BUTUH KUE ULANG TAHUN', 'minta tolong dibuatkan kue ulangtahun untuk para tukang yang sedang ulang tahun\r\n', 1, 'admin01', 'admin01', '2024-03-01 15:24:24', '2024-03-01 15:24:24', '0000-00-00 00:00:00', 1, 'REQ006/03/2024', 0, 1, 0),
(23, 5, 6, 'ROTI BAKAR HABIS', 'minta tolong dibuatkan roti bakar dengan jumlah yang lebih banyak agar stok tidak habis', 1, 'satria', 'admin01', '2024-03-01 15:30:03', '2024-03-20 14:17:14', '0000-00-00 00:00:00', 2, 'REQ007/03/2024', 0, 10, 1),
(24, 5, 6, 'ROTI BAKAR', 'minta dibuatkan menu baru roti bakar karena peminatnya banyak', 5, 'admin01', 'bagas', '2024-03-02 17:26:16', '2024-03-03 18:50:32', '0000-00-00 00:00:00', 1, 'REQ008/03/2024', 0, 1, 0),
(25, 5, 6, 'REQUEST KUE NASTAR', 'minta tolong dibuatkan kue nastar karena laku pas waktu indul fitri', 1, 'admin01', 'admin01', '2024-03-08 16:11:19', '2024-03-08 16:11:19', '0000-00-00 00:00:00', 2, 'REQ009/03/2024', 0, 1, 0),
(26, 5, 6, 'OUTKET TERBANG', 'Dikarenakan outlet barata terbang tertiup angin untuk sementara mengungsi ke outlet nias', 1, 'admin01', 'admin01', '2024-03-16 09:12:52', '2024-03-20 14:23:07', '0000-00-00 00:00:00', 1, 'REQ010/03/2024', 0, 1, 1);

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
  `chat_id_telegram` bigint(11) NOT NULL,
  `is_admin` tinyint(1) NOT NULL,
  `id_cabang` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `username`, `password`, `fullname`, `divisi_id`, `user_crt`, `user_upd`, `dtm_crt`, `dtm_upd`, `chat_id_telegram`, `is_admin`, `id_cabang`) VALUES
(1, 'admin01', 'Wzmb8+GoyAQ=', 'HANDY SATRIA', 5, 'system', 'admin01', '2024-02-22 10:06:12', '2024-03-01 13:01:18', 1486234824, 1, 1),
(2, 'bagas', 'LT3UArJ8LQQ=', 'BAGAS KAHFAA', 6, 'admin01', 'admin01', '2024-02-26 09:24:34', '2024-02-26 10:28:51', 1486234824, 0, 2),
(3, 'maulana', 'W34DDTl2hBI=', 'EGY MAULANA', 1, 'admin01', 'admin01', '2024-02-26 09:33:42', '2024-02-26 09:33:42', 1486234824, 0, 3),
(4, 'arhan', 'UrlBG1zKFRE=', 'ARHAN PRATAMA', 2, 'admin01', 'admin01', '2024-02-26 09:34:14', '2024-02-26 09:34:14', 6035045658, 0, 4),
(5, 'bambang', 'GJCH3OtiqDs=', 'BAMBANG PAMUNGKAS', 4, 'admin01', 'admin01', '2024-02-26 09:34:50', '2024-02-26 10:29:54', 1486234824, 0, 5),
(7, 'luhut', 'sY6gPsscmA8=', 'LUHUT BINSAR', 9, 'admin01', 'admin01', '2024-02-26 10:35:24', '2024-02-26 10:35:52', 1486234824, 1, 6),
(10, 'satria', '4wiVQZZOT20=', 'SATRIA', 5, 'admin01', 'admin01', '2024-02-29 15:45:14', '2024-03-01 15:53:42', 2147483647, 0, 8),
(11, 'okky', 'yYXzE2ciDCM=', 'OKKY CANDRA', 4, 'admin01', 'admin01', '2024-02-29 15:45:54', '2024-02-29 15:45:54', 592651364, 0, 16),
(12, 'gonzales', '34X6yUE+oW764+9kWtll1w==', 'GONZALES', 3, 'admin01', 'admin01', '2024-03-01 11:35:30', '2024-03-01 11:35:30', 1486234824, 0, 6),
(15, 'ronaldo', 'CQctnu45JsA=', 'RONALDO', 1, 'admin01', 'admin01', '2024-03-20 11:56:26', '2024-03-20 11:56:46', 123, 0, 25);

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
  MODIFY `divisi_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `hist_request`
--
ALTER TABLE `hist_request`
  MODIFY `hist_request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

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
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

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



