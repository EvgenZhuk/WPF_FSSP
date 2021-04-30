using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WPF_FSSP
{
    public partial class umsContext : DbContext
    {
        public umsContext()
        {
        }

        public umsContext(DbContextOptions<umsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcsSessionsInfo> AcsSessionsInfos { get; set; }
        public virtual DbSet<CourtObject> CourtObjects { get; set; }
        public virtual DbSet<CourtStation> CourtStations { get; set; }
        public virtual DbSet<CovidContactState> CovidContactStates { get; set; }
        public virtual DbSet<CovidInfectedState> CovidInfectedStates { get; set; }
        public virtual DbSet<FsspViolator> FsspViolators { get; set; }
        public virtual DbSet<IdentityDocument> IdentityDocuments { get; set; }
        public virtual DbSet<IdentityDocumentAuthenticityResult> IdentityDocumentAuthenticityResults { get; set; }
        public virtual DbSet<IdentityDocumentComparisonInfo> IdentityDocumentComparisonInfos { get; set; }
        public virtual DbSet<IdentityDocumentImage> IdentityDocumentImages { get; set; }
        public virtual DbSet<MiaViolator> MiaViolators { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PathmanCacheStat> PathmanCacheStats { get; set; }
        public virtual DbSet<PathmanConcurrentPartTask> PathmanConcurrentPartTasks { get; set; }
        public virtual DbSet<PathmanPartitionList> PathmanPartitionLists { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercaches { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServiceOrganization> ServiceOrganizations { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<VisitorDeclineReason> VisitorDeclineReasons { get; set; }
        public virtual DbSet<VisitorToCourtStation> VisitorToCourtStations { get; set; }
        public virtual DbSet<VisitorViolationCheck> VisitorViolationChecks { get; set; }

        // Unable to generate entity type for table 'public.pathman_config_params' since its primary key could not be scaffolded. Please see the warning messages.
        // Unable to generate entity type for table 'public.pathman_config' since its primary key could not be scaffolded. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=172.17.75.4;Port=5432;Database=ums;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_pathman")
                .HasPostgresExtension("pg_stat_statements")
                .HasAnnotation("Relational:Collation", "ru_RU.UTF-8");

            modelBuilder.Entity<AcsSessionsInfo>(entity =>
            {
                entity.ToTable("acs_sessions_info");

                entity.HasComment("Информация о сессиях СКУД");

                entity.HasIndex(e => e.Id, "IX_acs_sessions_info_id")
                    .IsUnique();

                entity.HasIndex(e => e.SessionId, "IX_acs_sessions_info_session_id");

                entity.HasIndex(e => e.VisitorId, "IX_acs_sessions_info_visitor_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('asc_sessions_info_id_seq'::regclass)");

                entity.Property(e => e.IsForgotten)
                    .HasColumnName("is_forgotten")
                    .HasComment("Признак 'сессия забыта '");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("session_id")
                    .HasComment("Идентификатор сессии");

                entity.Property(e => e.VisitorId)
                    .HasColumnName("visitor_id")
                    .HasComment("Идентификатор посетителя");

                entity.HasOne(d => d.Visitor)
                    .WithOne(p => p.AcsSessionsInfo)
                    .HasForeignKey<AcsSessionsInfo>(d => d.VisitorId);
            });

            modelBuilder.Entity<CourtObject>(entity =>
            {
                entity.ToTable("court_objects");

                entity.HasComment("Объекты с судебными участками");

                entity.HasIndex(e => e.Id, "IX_court_objects_id")
                    .IsUnique();

                entity.HasIndex(e => e.Number, "IX_court_objects_number")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessControlSystem)
                    .HasColumnName("access_control_system")
                    .HasComment("Флаг наличия СКУД");

                entity.Property(e => e.AccessControlSystemUrl)
                    .HasColumnName("access_control_system_url")
                    .HasComment("Url служб СКУД на объекте");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("address")
                    .HasComment("Адрес объекта");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasComment("Номер объекта");
            });

            modelBuilder.Entity<CourtStation>(entity =>
            {
                entity.ToTable("court_stations");

                entity.HasComment("Судебные участки");

                entity.HasIndex(e => e.CourtObjectId, "IX_court_stations_court_object_id");

                entity.HasIndex(e => e.Id, "IX_court_stations_id")
                    .IsUnique();

                entity.HasIndex(e => e.Number, "IX_court_stations_number")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourtObjectId)
                    .HasColumnName("court_object_id")
                    .HasComment("Идентификатор объекта, которому принадлежит данный участок");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasComment("Номер участка");

                entity.HasOne(d => d.CourtObject)
                    .WithMany(p => p.CourtStations)
                    .HasForeignKey(d => d.CourtObjectId);
            });

            modelBuilder.Entity<CovidContactState>(entity =>
            {
                entity.ToTable("covid_contact_states");

                entity.HasComment("Справочник статусов контактирования с заболевшим COVID");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Наименование статуса");
            });

            modelBuilder.Entity<CovidInfectedState>(entity =>
            {
                entity.ToTable("covid_infected_states");

                entity.HasComment("Справочник статусов заболеваемости COVID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Наименование статуса");
            });

            modelBuilder.Entity<FsspViolator>(entity =>
            {
                entity.ToTable("fssp_violators");

                entity.HasComment("Нарушители из списка ФССП");

                entity.HasIndex(e => e.Id, "IX_fssp_violators_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(1000)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasComment("Дата рождения");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .HasColumnName("comment")
                    .HasComment("Комментарий");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasComment("Дата создания записи");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(255)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество");
            });

            modelBuilder.Entity<IdentityDocument>(entity =>
            {
                entity.ToTable("identity_documents");

                entity.HasComment("Документы, удостоверяющие личность");

                entity.HasIndex(e => e.Id, "IX_identity_documents_id")
                    .IsUnique();

                entity.HasIndex(e => e.VisitorId, "IX_identity_documents_visitor_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasComment("Дата создания");

                entity.Property(e => e.DocumentType)
                    .HasColumnName("document_type")
                    .HasComment("Тип документа");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasComment("Номер документа");

                entity.Property(e => e.PortraitImageBytes)
                    .HasColumnName("portrait_image_bytes")
                    .HasComment("Изображение портрета из документов");

                entity.Property(e => e.PortraitImageFormat)
                    .HasColumnName("portrait_image_format")
                    .HasComment("Формат изображения портрета из документов");

                entity.Property(e => e.VisitorId)
                    .HasColumnName("visitor_id")
                    .HasComment("Идентификатор посетителя");

                entity.HasOne(d => d.Visitor)
                    .WithOne(p => p.IdentityDocument)
                    .HasForeignKey<IdentityDocument>(d => d.VisitorId);
            });

            modelBuilder.Entity<IdentityDocumentAuthenticityResult>(entity =>
            {
                entity.ToTable("identity_document_authenticity_results");

                entity.HasComment("Данные о результатах различных проверок подлинности документа");

                entity.HasIndex(e => e.Id, "IX_identity_document_authenticity_results_id")
                    .IsUnique();

                entity.HasIndex(e => e.IdentityDocumentId, "IX_identity_document_authenticity_results_identity_document_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BarcodeFormat)
                    .HasColumnName("barcode_format")
                    .HasComment("Результат проверки формата штрихкода");

                entity.Property(e => e.BlankLuminescence)
                    .HasColumnName("blank_luminescence")
                    .HasComment("Результат проверки люминесценции бланка");

                entity.Property(e => e.FibersLuminescence)
                    .HasColumnName("fibers_luminescence")
                    .HasComment("Результат проверки свечения волокон");

                entity.Property(e => e.HiddenPhotoVisualization)
                    .HasColumnName("hidden_photo_visualization")
                    .HasComment("Результат проверки видимости скрытой люмицисценции");

                entity.Property(e => e.Holograms)
                    .HasColumnName("holograms")
                    .HasComment("Результат проверки присутствия голограмм");

                entity.Property(e => e.IdentityDocumentId)
                    .HasColumnName("identity_document_id")
                    .HasComment("Идентификатор документа, удостоверяющего личность");

                entity.Property(e => e.ImagePattern)
                    .HasColumnName("image_pattern")
                    .HasComment("Результат проверки люминесцирующих рисунков в ультрафиолетовом спектре");

                entity.Property(e => e.IrBlankVisibility)
                    .HasColumnName("ir_blank_visibility")
                    .HasComment("Результат проверки видимости бланка в инфракрасном спектре");

                entity.Property(e => e.IrFillVisibility)
                    .HasColumnName("ir_fill_visibility")
                    .HasComment("Результат проверки видимости заполнения в инфракрасном спектре");

                entity.Property(e => e.IrPhotoVisibility)
                    .HasColumnName("ir_photo_visibility")
                    .HasComment("Результат проверки видимости фотографии в инфракрасном спектреа");

                entity.Property(e => e.MrzLuminescence)
                    .HasColumnName("mrz_luminescence")
                    .HasComment("Результат проверки люминесценции машиносчитываемой зоны");

                entity.Property(e => e.MrzPrintContrast)
                    .HasColumnName("mrz_print_contrast")
                    .HasComment("Результат проверки контраста печати машиносчитываемой зоны");

                entity.Property(e => e.PhotoEmbedType)
                    .HasColumnName("photo_embed_type")
                    .HasComment("Напечатана фотография или вклеена");

                entity.Property(e => e.PhotoEmbedding)
                    .HasColumnName("photo_embedding")
                    .HasComment("Результат проверки, что фотография вклеена или напечатана правильно");

                entity.Property(e => e.PhotoLuminescence)
                    .HasColumnName("photo_luminescence")
                    .HasComment("Результат проверки люминесценции фотографии");

                entity.Property(e => e.RetroflexProtection)
                    .HasColumnName("retroflex_protection")
                    .HasComment("Результат проверки ретрорефлекторной защиты");

                entity.HasOne(d => d.IdentityDocument)
                    .WithOne(p => p.IdentityDocumentAuthenticityResult)
                    .HasForeignKey<IdentityDocumentAuthenticityResult>(d => d.IdentityDocumentId)
                    .HasConstraintName("FK_identity_document_authenticity_results_identity_documents_i~");
            });

            modelBuilder.Entity<IdentityDocumentComparisonInfo>(entity =>
            {
                entity.ToTable("identity_document_comparison_infos");

                entity.HasComment("Данные о перекрёстных проверках значений поля, полученных разным способом при сканировании и распознавании документа");

                entity.HasIndex(e => e.Id, "IX_identity_document_comparison_infos_id")
                    .IsUnique();

                entity.HasIndex(e => e.IdentityDocumentId, "IX_identity_document_comparison_infos_identity_document_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdentityDocumentId)
                    .HasColumnName("identity_document_id")
                    .HasComment("Идентификатор документа, удостоверяющего личность");

                entity.Property(e => e.MrzWithBarcode)
                    .HasColumnName("mrz_with_barcode")
                    .HasComment("Результат сравнения значений из машинносчитываемой зоны и штрихкода");

                entity.Property(e => e.MrzWithRfid)
                    .HasColumnName("mrz_with_rfid")
                    .HasComment("Результат сравнения значений из машинносчитываемой зоны и RFID");

                entity.Property(e => e.MrzWithText)
                    .HasColumnName("mrz_with_text")
                    .HasComment("Результат сравнения значений из машинносчитываемой зоны и распознанного визуального поля");

                entity.Property(e => e.RfidWithBarcode)
                    .HasColumnName("rfid_with_barcode")
                    .HasComment("Результат сравнения значений из RFID и штрихкода");

                entity.Property(e => e.TextWithBarcode)
                    .HasColumnName("text_with_barcode")
                    .HasComment("Результат сравнения значений из распознанного визуального поля и штрихкода");

                entity.Property(e => e.TextWithRfid)
                    .HasColumnName("text_with_rfid")
                    .HasComment("Результат сравнения значений из распознанного визуального поля и RFID");

                entity.HasOne(d => d.IdentityDocument)
                    .WithOne(p => p.IdentityDocumentComparisonInfo)
                    .HasForeignKey<IdentityDocumentComparisonInfo>(d => d.IdentityDocumentId)
                    .HasConstraintName("FK_identity_document_comparison_infos_identity_documents_ident~");
            });

            modelBuilder.Entity<IdentityDocumentImage>(entity =>
            {
                entity.ToTable("identity_document_images");

                entity.HasComment("Изображения документов, удостоверяющих личность");

                entity.HasIndex(e => e.Id, "IX_identity_document_images_id")
                    .IsUnique();

                entity.HasIndex(e => e.IdentityDocumentId, "IX_identity_document_images_identity_document_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Extension)
                    .HasMaxLength(15)
                    .HasColumnName("extension")
                    .HasComment("Расширение файла");

                entity.Property(e => e.IdentityDocumentId)
                    .HasColumnName("identity_document_id")
                    .HasComment("Идентификатор документа, удостоверяющий личность");

                entity.Property(e => e.ImageType)
                    .HasColumnName("image_type")
                    .HasComment("Тип изображения");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .HasColumnName("path")
                    .HasComment("Путь к файлу");

                entity.Property(e => e.SizeInBytes)
                    .HasColumnName("size_in_bytes")
                    .HasComment("Размер файла в байтах");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UploadedDate)
                    .HasColumnName("uploaded_date")
                    .HasComment("Дата загрузки");

                entity.HasOne(d => d.IdentityDocument)
                    .WithMany(p => p.IdentityDocumentImages)
                    .HasForeignKey(d => d.IdentityDocumentId)
                    .HasConstraintName("FK_identity_document_images_identity_documen___dbebca45f6524185");
            });

            modelBuilder.Entity<MiaViolator>(entity =>
            {
                entity.ToTable("mia_violators");

                entity.HasComment("Нарушители из списка МВД");

                entity.HasIndex(e => e.Id, "IX_mia_violators_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(1000)
                    .HasColumnName("birth_place")
                    .HasComment("Место рождения");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasComment("Дата рождения");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .HasColumnName("comment")
                    .HasComment("Комментарий");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasComment("Дата создания записи");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(255)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notifications");

                entity.HasComment("Уведомления");

                entity.HasIndex(e => e.Id, "IX_notifications_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromDateTime)
                    .HasColumnName("from_date_time")
                    .HasComment("Дата и время начала действия уведомления");

                entity.Property(e => e.InformationText)
                    .IsRequired()
                    .HasColumnName("information_text")
                    .HasComment("Текст уведомления");

                entity.Property(e => e.NotificationType)
                    .HasColumnName("notification_type")
                    .HasComment("Тип уведомления");

                entity.Property(e => e.ToDateTime)
                    .HasColumnName("to_date_time")
                    .HasComment("Дата и время окончания действия уведомления");
            });

            modelBuilder.Entity<PathmanCacheStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pathman_cache_stats");

                entity.Property(e => e.Context).HasColumnName("context");

                entity.Property(e => e.Entries).HasColumnName("entries");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Used).HasColumnName("used");
            });

            modelBuilder.Entity<PathmanConcurrentPartTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pathman_concurrent_part_tasks");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<PathmanPartitionList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pathman_partition_list");

                entity.Property(e => e.Expr).HasColumnName("expr");

                entity.Property(e => e.Parttype).HasColumnName("parttype");

                entity.Property(e => e.RangeMax).HasColumnName("range_max");

                entity.Property(e => e.RangeMin).HasColumnName("range_min");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnType("oid")
                    .HasColumnName("reldatabase");

                entity.Property(e => e.Relfilenode)
                    .HasColumnType("oid")
                    .HasColumnName("relfilenode");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnType("oid")
                    .HasColumnName("reltablespace");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasComment("Роли пользователей");

                entity.HasIndex(e => e.Name, "IX_roles_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("display_name")
                    .HasComment("Отображаемое имя роли");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasComment("Уникальное имя роли");
            });

            modelBuilder.Entity<ServiceOrganization>(entity =>
            {
                entity.ToTable("service_organizations");

                entity.HasComment("Обслуживающие организации");

                entity.HasIndex(e => e.Id, "IX_service_organizations_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("Название");
            });

            modelBuilder.Entity<UploadedFile>(entity =>
            {
                entity.ToTable("uploaded_files");

                entity.HasIndex(e => e.Id, "IX_uploaded_files_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Extension)
                    .HasMaxLength(15)
                    .HasColumnName("extension");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(1023)
                    .HasColumnName("path");

                entity.Property(e => e.SizeInBytes).HasColumnName("size_in_bytes");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UploadedDate).HasColumnName("uploaded_date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasComment("Пользователи системы");

                entity.HasIndex(e => e.Name, "IX_users_name")
                    .IsUnique();

                entity.HasIndex(e => e.SyncDate, "IX_users_sync_date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasComment("Уникальное имя пользователя");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(255)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество");

                entity.Property(e => e.SyncDate)
                    .HasColumnName("sync_date")
                    .HasDefaultValueSql("'0001-01-01 00:00:00'::timestamp without time zone")
                    .HasComment("Дата последней синхронизации записи с внешними источниками");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.HasComment("Связанные с пользователем роли");

                entity.HasIndex(e => e.CourtObjectId, "IX_user_roles_court_object_id");

                entity.HasIndex(e => e.RoleId, "IX_user_roles_role_id");

                entity.HasIndex(e => e.UserId, "IX_user_roles_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourtObjectId)
                    .HasColumnName("court_object_id")
                    .HasComment("Идентификатор участка для роли \"Охранник\"");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasComment("Идентификатор роли");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasComment("Идентификатор пользователя");

                entity.HasOne(d => d.CourtObject)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.CourtObjectId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.ToTable("visitors");

                entity.HasComment("Посетители");

                entity.HasIndex(e => e.CourtObjectId, "IX_visitors_court_object_id");

                entity.HasIndex(e => e.Id, "IX_visitors_id")
                    .IsUnique();

                entity.HasIndex(e => e.ProcessDate, "IX_visitors_process_date");

                entity.HasIndex(e => e.ServiceOrganizationId, "IX_visitors_service_organization_id");

                entity.HasIndex(e => e.State, "IX_visitors_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasComment("Дата рождения");

                entity.Property(e => e.Commentary)
                    .HasMaxLength(256)
                    .HasColumnName("commentary")
                    .HasComment("Комментарий");

                entity.Property(e => e.CourtObjectId)
                    .HasColumnName("court_object_id")
                    .HasComment("Идентификатор посещённого объекта");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasComment("Дата регистрации");

                entity.Property(e => e.ExitDate)
                    .HasColumnName("exit_date")
                    .HasComment("Дата выхода с объекта");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .HasComment("Имя");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(255)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasDefaultValueSql("currval('visitors_id_seq'::regclass)")
                    .HasComment("Идентификатор физ. лица");

                entity.Property(e => e.ProcessDate)
                    .HasColumnName("process_date")
                    .HasComment("Дата обработки посетителя");

                entity.Property(e => e.ServiceOrganizationId)
                    .HasColumnName("service_organization_id")
                    .HasComment("Идентификатор обслуживающей организации");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasComment("Статус посетителя");

                entity.Property(e => e.VisitDate)
                    .HasColumnName("visit_date")
                    .HasComment("Дата входа на объект");

                entity.HasOne(d => d.CourtObject)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.CourtObjectId);

                entity.HasOne(d => d.ServiceOrganization)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.ServiceOrganizationId);
            });

            modelBuilder.Entity<VisitorDeclineReason>(entity =>
            {
                entity.ToTable("visitor_decline_reasons");

                entity.HasComment("Справочник причин отказов посетителям в посещении МС");

                entity.HasIndex(e => e.Id, "IX_visitor_decline_reasons_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasComment("Описание причины");
            });

            modelBuilder.Entity<VisitorToCourtStation>(entity =>
            {
                entity.ToTable("visitor_to_court_station");

                entity.HasComment("Таблица связей посетителей и посещаемых участков");

                entity.HasIndex(e => new { e.CourtStationId, e.VisitorId }, "IX_visitor_to_court_station_court_station_id_visitor_id")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "IX_visitor_to_court_station_id")
                    .IsUnique();

                entity.HasIndex(e => e.VisitorId, "IX_visitor_to_court_station_visitor_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourtStationId)
                    .HasColumnName("court_station_id")
                    .HasComment("Посещаемый участок");

                entity.Property(e => e.VisitorId)
                    .HasColumnName("visitor_id")
                    .HasComment("Посетитель");

                entity.HasOne(d => d.CourtStation)
                    .WithMany(p => p.VisitorToCourtStations)
                    .HasForeignKey(d => d.CourtStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_court_station_to_visitor_CourtStationId");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.VisitorToCourtStations)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_court_station_to_visitor_VisitorId");
            });

            modelBuilder.Entity<VisitorViolationCheck>(entity =>
            {
                entity.ToTable("visitor_violation_checks");

                entity.HasComment("Проверки посетителей на нарушения");

                entity.HasIndex(e => e.Id, "IX_visitor_violation_checks_id")
                    .IsUnique();

                entity.HasIndex(e => e.VisitorId, "IX_visitor_violation_checks_visitor_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CovidCheckResult)
                    .HasColumnName("covid_check_result")
                    .HasComment("Результат проверки COVID из соц. мониторинга");

                entity.Property(e => e.CovidQuarantineEndDate)
                    .HasColumnName("covid_quarantine_end_date")
                    .HasComment("Дата окончания карантина COVID");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasComment("Дата создания");

                entity.Property(e => e.FsspCheckResult)
                    .HasColumnName("fssp_check_result")
                    .HasComment("Результат проверки в реестрах ФССП");

                entity.Property(e => e.FsspCommentary)
                    .HasColumnName("fssp_commentary")
                    .HasComment("Комментарий из реестра ФССП");

                entity.Property(e => e.MiaCheckResult)
                    .HasColumnName("mia_check_result")
                    .HasComment("Результат проверки в реестрах МВД");

                entity.Property(e => e.MiaCommentary)
                    .HasColumnName("mia_commentary")
                    .HasComment("Комментарий из реестра МВД");

                entity.Property(e => e.VisitorId)
                    .HasColumnName("visitor_id")
                    .HasComment("Идентификатор посетителя");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.VisitorViolationChecks)
                    .HasForeignKey(d => d.VisitorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
