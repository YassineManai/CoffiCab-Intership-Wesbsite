using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManufacturingExecutionSystem1.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    CodeProcess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPorcess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rework = table.Column<bool>(type: "bit", nullable: false),
                    WithSetupMandatory = table.Column<bool>(type: "bit", nullable: false),
                    WithToolingVerification = table.Column<bool>(type: "bit", nullable: false),
                    WithIncomplete = table.Column<bool>(type: "bit", nullable: false),
                    WithQuality = table.Column<bool>(type: "bit", nullable: false),
                    WithValidationManualReport = table.Column<bool>(type: "bit", nullable: false),
                    WithQualityReturnValidation = table.Column<bool>(type: "bit", nullable: false),
                    ReturnValidationProfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseWithSupplierCode = table.Column<bool>(type: "bit", nullable: false),
                    InputForCmes = table.Column<bool>(type: "bit", nullable: false),
                    WarehouseCMES = table.Column<bool>(type: "bit", nullable: false),
                    Quality_100_100 = table.Column<bool>(type: "bit", nullable: false),
                    WarehouseIncomplet = table.Column<bool>(type: "bit", nullable: false),
                    With_Metalic_Number_In_Prod = table.Column<bool>(type: "bit", nullable: false),
                    Cnx_Par_Zone = table.Column<bool>(type: "bit", nullable: false),
                    With_Demarrage = table.Column<bool>(type: "bit", nullable: false),
                    NB_Wire_Fois_Recette = table.Column<bool>(type: "bit", nullable: false),
                    Img_Process = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeProcessToRework = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock_In_LPDM = table.Column<bool>(type: "bit", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dechet_Activate = table.Column<bool>(type: "bit", nullable: false),
                    PLC_Assigned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_Metal = table.Column<bool>(type: "bit", nullable: false),
                    Many_Output_For_One_Input = table.Column<bool>(type: "bit", nullable: false),
                    Model_Label = table.Column<int>(type: "int", nullable: false),
                    Input_Manual_MetaliqueNumber = table.Column<bool>(type: "bit", nullable: false),
                    WithoutFifo = table.Column<bool>(type: "bit", nullable: false),
                    Long_Machine_Stop_min = table.Column<int>(type: "int", nullable: false),
                    FTQwithFirstValidationQuality = table.Column<bool>(type: "bit", nullable: false),
                    HV_TEST = table.Column<bool>(type: "bit", nullable: false),
                    WithValidationRequestInsolation = table.Column<bool>(type: "bit", nullable: false),
                    WithValidationRequestColorant = table.Column<bool>(type: "bit", nullable: false),
                    WithScrapDeclaration = table.Column<bool>(type: "bit", nullable: false),
                    QAStopLabelRed = table.Column<bool>(type: "bit", nullable: false),
                    Hide_HU_from_NOK_Quality_label = table.Column<bool>(type: "bit", nullable: false),
                    FTQ_update_in_the_Same_Shift = table.Column<bool>(type: "bit", nullable: false),
                    Accept_OK_NOT_INC_Spools_As_input_Rewinders = table.Column<bool>(type: "bit", nullable: false),
                    EventDetectionIncludeSpooler = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.CodeProcess);
                });

            migrationBuilder.CreateTable(
                name: "ProfilUser",
                columns: table => new
                {
                    Id_Profil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDProfiUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilUser", x => x.Id_Profil);
                });

            migrationBuilder.CreateTable(
                name: "Caracters",
                columns: table => new
                {
                    CodeCaracter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDCaracters = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescCaracter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit_of_measure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithMaxMinValue = table.Column<bool>(type: "bit", nullable: false),
                    Visual_Value = table.Column<bool>(type: "bit", nullable: false),
                    IsUCS = table.Column<bool>(type: "bit", nullable: false),
                    Activated = table.Column<bool>(type: "bit", nullable: false),
                    IsSearchCreteria = table.Column<bool>(type: "bit", nullable: false),
                    Visible_InProductionView = table.Column<bool>(type: "bit", nullable: false),
                    VisibleInQualityView = table.Column<bool>(type: "bit", nullable: false),
                    Valeur = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDatasheet = table.Column<bool>(type: "bit", nullable: false),
                    CodeProcess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForInput = table.Column<bool>(type: "bit", nullable: false),
                    MasqueSaisie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regroupement_Libille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordre_Regroupement_Libille = table.Column<int>(type: "int", nullable: false),
                    Ordre_Caracter = table.Column<int>(type: "int", nullable: false),
                    ParamStartOfShift = table.Column<bool>(type: "bit", nullable: false),
                    Code_OPC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalDescCaracter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsToolingParameter = table.Column<bool>(type: "bit", nullable: false),
                    Image_Caracters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpeed = table.Column<bool>(type: "bit", nullable: false),
                    Saisie_Automatique = table.Column<bool>(type: "bit", nullable: false),
                    IsRepetitif = table.Column<bool>(type: "bit", nullable: false),
                    Lien_Cararactere_Nb_Repetition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResistance = table.Column<bool>(type: "bit", nullable: false),
                    Print_Character_In_Separate_Label = table.Column<bool>(type: "bit", nullable: false),
                    Activer_Controle_Soumission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracters", x => x.CodeCaracter);
                    table.ForeignKey(
                        name: "FK_Caracters_Process_CodeProcess",
                        column: x => x.CodeProcess,
                        principalTable: "Process",
                        principalColumn: "CodeProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Machine_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPlant_Machine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOK_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOK_Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OK_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OK_Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeProcess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bulding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_Machine_OPC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code_Machine_Serial_Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActualUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aff_Input_Interface_Prod = table.Column<byte>(type: "tinyint", nullable: true),
                    OnlyWithPO = table.Column<bool>(type: "bit", nullable: true),
                    ActualRecette_ValitadedSetup = table.Column<bool>(type: "bit", nullable: true),
                    With_Consumption = table.Column<bool>(type: "bit", nullable: true),
                    With_Integration_ERP = table.Column<bool>(type: "bit", nullable: true),
                    Dec_In_Quality = table.Column<bool>(type: "bit", nullable: true),
                    ActualUser_Qualite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    With_Contro_Input_BOM = table.Column<bool>(type: "bit", nullable: true),
                    RepertoireReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepertoireReportArchive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepertoireReportRejete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rapport_Externe = table.Column<bool>(type: "bit", nullable: true),
                    SN_Machine = table.Column<bool>(type: "bit", nullable: true),
                    Plan_Affichage_Interface_Prod = table.Column<byte>(type: "tinyint", nullable: true),
                    Verifiation_Complement_Par_Ligne = table.Column<bool>(type: "bit", nullable: true),
                    With_Remplissage = table.Column<bool>(type: "bit", nullable: true),
                    StartingTimeCalculeStop = table.Column<int>(type: "int", nullable: true),
                    Format_Date_Report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    affectation_Direct_Ray = table.Column<bool>(type: "bit", nullable: true),
                    ReadingReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerrouOF = table.Column<bool>(type: "bit", nullable: true),
                    Type_Fic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_Machine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grp_Objectif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_Process2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wip_After_Validation_QA = table.Column<bool>(type: "bit", nullable: true),
                    Without_Quality = table.Column<bool>(type: "bit", nullable: true),
                    Print_Label_CB_QA = table.Column<bool>(type: "bit", nullable: true),
                    TraitementPO = table.Column<byte>(type: "tinyint", nullable: true),
                    NotConnected = table.Column<bool>(type: "bit", nullable: true),
                    ImprimanteCmes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImprimantePanel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    With_Consumption_ERP = table.Column<bool>(type: "bit", nullable: true),
                    With_Control_Insolation = table.Column<bool>(type: "bit", nullable: true),
                    With_Control_Colorant = table.Column<bool>(type: "bit", nullable: true),
                    With_Control_Tape = table.Column<bool>(type: "bit", nullable: true),
                    With_Sequential_Consumption = table.Column<bool>(type: "bit", nullable: true),
                    WithScrapDeclaration = table.Column<bool>(type: "bit", nullable: true),
                    ScrapDeclarationMode_A_1_M_0 = table.Column<bool>(type: "bit", nullable: true),
                    With_CB_In_Production_NOK = table.Column<bool>(type: "bit", nullable: true),
                    IRR_Real_Time_From_XML_File = table.Column<bool>(type: "bit", nullable: true),
                    Disable_the_use_of_Machine_detected_Issues = table.Column<bool>(type: "bit", nullable: true),
                    With_delete_report = table.Column<bool>(type: "bit", nullable: true),
                    TPV100_100 = table.Column<bool>(type: "bit", nullable: true),
                    With_Many_Input_For_Extrusion = table.Column<bool>(type: "bit", nullable: true),
                    Time_waiting_before_validation_next_report = table.Column<int>(type: "int", nullable: true),
                    Modif_Recipe_OPC_MUL = table.Column<bool>(type: "bit", nullable: true),
                    Read_Report_With_Windows_Service = table.Column<bool>(type: "bit", nullable: true),
                    With_PO_First = table.Column<bool>(type: "bit", nullable: true),
                    WorkCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inc_Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inc_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup_Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection_Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection_Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Machine_Code);
                    table.ForeignKey(
                        name: "FK_Machine_Process_CodeProcess",
                        column: x => x.CodeProcess,
                        principalTable: "Process",
                        principalColumn: "CodeProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeProcess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentIDProduct = table.Column<int>(type: "int", nullable: false),
                    CodeItemModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ITemGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumptionPerOneKM_outPut = table.Column<float>(type: "real", nullable: false),
                    CodePAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COdeTPV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeItemNature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodeRecette = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    CunsumptionCopperKgPerOneKM = table.Column<int>(type: "int", nullable: false),
                    CunsumptionPVCKgPerOneKM = table.Column<int>(type: "int", nullable: false),
                    Famille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleurP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleurS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeMatiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diametre = table.Column<double>(type: "float", nullable: false),
                    m_min_m_sec = table.Column<byte>(type: "tinyint", nullable: false),
                    CodePAC_DVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeItemModel_DVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code_Recette_DVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    With_Rewinder = table.Column<bool>(type: "bit", nullable: false),
                    FG = table.Column<bool>(type: "bit", nullable: false),
                    InforItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_WIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResistanceOptimal = table.Column<float>(type: "real", nullable: false),
                    CodeTPV_DVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poids_Conducteur_Kg_Km = table.Column<float>(type: "real", nullable: false),
                    Poids_Insolation_Kg_Km = table.Column<float>(type: "real", nullable: false),
                    Couleur_Marquage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ItemCode);
                    table.ForeignKey(
                        name: "FK_Product_Process_CodeProcess",
                        column: x => x.CodeProcess,
                        principalTable: "Process",
                        principalColumn: "CodeProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Process_ProfilUsers",
                columns: table => new
                {
                    CodeProcess = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Id_Profil = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process_ProfilUsers", x => new { x.CodeProcess, x.Id_Profil });
                    table.ForeignKey(
                        name: "FK_Process_ProfilUsers_Process_CodeProcess",
                        column: x => x.CodeProcess,
                        principalTable: "Process",
                        principalColumn: "CodeProcess",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Process_ProfilUsers_ProfilUser_Id_Profil",
                        column: x => x.Id_Profil,
                        principalTable: "ProfilUser",
                        principalColumn: "Id_Profil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgProfils",
                columns: table => new
                {
                    IDProgProfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Profil = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LibProgramme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomProgramme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onlyconsultation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgProfils", x => x.IDProgProfil);
                    table.ForeignKey(
                        name: "FK_ProgProfils_ProfilUser_Id_Profil",
                        column: x => x.Id_Profil,
                        principalTable: "ProfilUser",
                        principalColumn: "Id_Profil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracterValues",
                columns: table => new
                {
                    IDCaracterValues = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value1Caracter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeCaracter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ITemGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value2Caracter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationArithmetique1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationArithmetique2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracterValues", x => x.IDCaracterValues);
                    table.ForeignKey(
                        name: "FK_CaracterValues_Caracters_CodeCaracter",
                        column: x => x.CodeCaracter,
                        principalTable: "Caracters",
                        principalColumn: "CodeCaracter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaractersStartOfShiftValues",
                columns: table => new
                {
                    CodeCaracterStartOFShift = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDCaractersStartOfShiftValues = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Poste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Machine_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaractersStartOfShiftValues", x => x.CodeCaracterStartOFShift);
                    table.ForeignKey(
                        name: "FK_CaractersStartOfShiftValues_Machine_Machine_Code",
                        column: x => x.Machine_Code,
                        principalTable: "Machine",
                        principalColumn: "Machine_Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caracters_CodeCaracter",
                table: "Caracters",
                column: "CodeCaracter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Caracters_CodeProcess",
                table: "Caracters",
                column: "CodeProcess");

            migrationBuilder.CreateIndex(
                name: "IX_CaractersStartOfShiftValues_CodeCaracterStartOFShift",
                table: "CaractersStartOfShiftValues",
                column: "CodeCaracterStartOFShift",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaractersStartOfShiftValues_Machine_Code",
                table: "CaractersStartOfShiftValues",
                column: "Machine_Code");

            migrationBuilder.CreateIndex(
                name: "IX_CaracterValues_CodeCaracter",
                table: "CaracterValues",
                column: "CodeCaracter");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Code_Machine_OPC",
                table: "Machine",
                column: "Code_Machine_OPC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Code_Machine_Serial_Number",
                table: "Machine",
                column: "Code_Machine_Serial_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machine_CodeProcess",
                table: "Machine",
                column: "CodeProcess");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Machine_Code",
                table: "Machine",
                column: "Machine_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_CodeProcess",
                table: "Process",
                column: "CodeProcess",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_ProfilUsers_Id_Profil",
                table: "Process_ProfilUsers",
                column: "Id_Profil");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CodeProcess",
                table: "Product",
                column: "CodeProcess");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ItemCode",
                table: "Product",
                column: "ItemCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_LocalItemCode",
                table: "Product",
                column: "LocalItemCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilUser_Id_Profil",
                table: "ProfilUser",
                column: "Id_Profil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgProfils_Id_Profil",
                table: "ProgProfils",
                column: "Id_Profil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaractersStartOfShiftValues");

            migrationBuilder.DropTable(
                name: "CaracterValues");

            migrationBuilder.DropTable(
                name: "Process_ProfilUsers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProgProfils");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Caracters");

            migrationBuilder.DropTable(
                name: "ProfilUser");

            migrationBuilder.DropTable(
                name: "Process");
        }
    }
}
