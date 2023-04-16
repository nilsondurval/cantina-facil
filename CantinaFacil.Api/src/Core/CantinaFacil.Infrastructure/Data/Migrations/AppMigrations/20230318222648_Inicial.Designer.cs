﻿// <auto-generated />
using System;
using CantinaFacil.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CantinaFacil.Infrastructure.Data.Migrations.AppMigrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230318222648_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Parametros.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_PARAMETRO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DS_PARAMETRO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NM_PARAMETRO");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TX_VALOR");

                    b.HasKey("Id")
                        .HasName("PK_PARAMETRO");

                    b.ToTable("TB_PARAMETRO", (string)null);
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Perfis.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_PERFIL");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NM_PERFIL");

                    b.HasKey("Id")
                        .HasName("PK_PERFIL");

                    b.ToTable("TB_DOM_PERFIL", (string)null);
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Perfis.PerfilPermissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_SUBPERFIL_PERMISSAO");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PERFIL");

                    b.Property<int>("PermissaoId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PERMISSAO");

                    b.HasKey("Id")
                        .HasName("PK_SUBPERFIL_PERMISSAO");

                    b.HasIndex("PerfilId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("TB_PERFIL_PERMISSAO", (string)null);
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Permissoes.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_PERMISSAO");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NM_PERMISSAO");

                    b.HasKey("Id")
                        .HasName("PK_PERMISSAO");

                    b.ToTable("TB_PERMISSAO", (string)null);
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_USUARIO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NR_CPF");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TX_EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NM_USUARIO");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PERFIL");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TX_TELEFONE");

                    b.HasKey("Id")
                        .HasName("PK_USUARIO");

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Perfis.PerfilPermissao", b =>
                {
                    b.HasOne("CantinaFacil.Domain.Aggregates.Perfis.Perfil", "Perfil")
                        .WithMany("PerfilPermissoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CantinaFacil.Domain.Aggregates.Permissoes.Permissao", "Permissao")
                        .WithMany("PerfilPermissoes")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Usuarios.Usuario", b =>
                {
                    b.HasOne("CantinaFacil.Domain.Aggregates.Perfis.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Perfis.Perfil", b =>
                {
                    b.Navigation("PerfilPermissoes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CantinaFacil.Domain.Aggregates.Permissoes.Permissao", b =>
                {
                    b.Navigation("PerfilPermissoes");
                });
#pragma warning restore 612, 618
        }
    }
}
